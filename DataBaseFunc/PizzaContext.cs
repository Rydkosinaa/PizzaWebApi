using DataBaseFunc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace DataBaseFunc
{
    internal class PizzaContext : DbContext
    {
        public DbSet<Bucket>? Bucket { get; set; }
        public DbSet<Pizza> Pizza { get; set; } = null!;

        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<PizzaIngridient> PizzaIngridients { get; set; } = null!;

        public PizzaContext(DbContextOptions context) : base(context)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bucket>().HasNoKey();
            modelBuilder
            .Entity<Pizza>()
            .HasMany(p => p.Ingredients)
            .WithMany(i => i.Pizzas)
            .UsingEntity<PizzaIngridient>(
               j => j
                .HasOne(pi => pi.Ingredient)
                .WithMany(t => t.PizzaIngridients)
                .HasForeignKey(pi => pi.IngName).OnDelete(DeleteBehavior.Restrict),
            j => j
                .HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngridients)
                .HasForeignKey(pi => pi.PizzaName).OnDelete(DeleteBehavior.Restrict),
            j =>
            {
                j.HasKey(t => new { t.PizzaName, t.IngName });
                j.ToTable("PizzaIngridient");
            });
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PizzaDataBase;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
