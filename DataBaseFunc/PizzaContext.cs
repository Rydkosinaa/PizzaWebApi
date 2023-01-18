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

        public PizzaContext(DbContextOptions context) : base(context)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bucket>().HasNoKey();
            modelBuilder.Entity<Pizza>()
                .HasMany<Ingredient>(p => p.PizzaIngredients)
                .WithMany(i => i.Pizzas)
                .UsingEntity(pi =>
                {
                    pi.HasKey("PizzaId");
                    pi.HasKey("IngId");
                    pi.ToTable("PizzaIng");
                });

            modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient() { Name = "Dough", Price = 10 },
                    new Ingredient() { Name = "Peperoni", Price = 1 },
                    new Ingredient() { Name = "Onion", Price = 2 },
                    new Ingredient() { Name = "Cheese", Price = 3 },
                    new Ingredient() { Name = "Tomato", Price = 5 },
                    new Ingredient() { Name = "Mushrooms", Price = 7 },
                    new Ingredient() { Name = "Mozarella", Price = 15 },
                    new Ingredient() { Name = "Peper", Price = 12 },
                    new Ingredient() { Name = "Salad", Price = 17 },
                    new Ingredient() { Name = "Salmon", Price = 17 },
                    new Ingredient() { Name = "Olives", Price = 12 }
                    );

            modelBuilder.Entity<Pizza>().HasData(
                        new Pizza() { PizzaPrice = 18, Name = "Margarita", PizzaIngredients = { new Ingredient() { Name = "Tomato", Price = 5 }, new Ingredient() { Name = "Cheese", Price = 3 }, } },
                        new Pizza() { PizzaPrice = 26, rating = 0, Name = "Peperoni", PizzaIngredients = { new Ingredient() { Name = "Onion", Price = 2 }, new Ingredient() { Name = "Peperoni", Price = 1 }, new Ingredient() {  Name = "Tomato", Price = 5 }, new Ingredient() { Name = "Cheese", Price = 3 } } },
                        new Pizza() { PizzaPrice = 31, rating = 0, Name = "Mushroom", PizzaIngredients = { new Ingredient() { Name = "Mushrooms", Price = 7 }, new Ingredient() { Name = "Onion", Price = 2 }, new Ingredient() { Name = "Peperoni", Price = 1 }, new Ingredient() { Name = "Tomato", Price = 5 }, new Ingredient() { Name = "Cheese", Price = 3 } } },
                        new Pizza() { PizzaPrice = 39, rating = 0, Name = "Mozarella", PizzaIngredients = { new Ingredient() { Name = "Mozarella", Price = 15 }, new Ingredient() { Name = "Onion", Price = 2 }, new Ingredient() { Name = "Peperoni", Price = 1 }, new Ingredient() { Name = "Tomato", Price = 5 }, new Ingredient() { Name = "Cheese", Price = 3 } } },
                        new Pizza() { PizzaPrice = 34, rating = 0, Name = "Vegitariana", PizzaIngredients = { new Ingredient() { Name = "Onion", Price = 2 }, new Ingredient() { Name = "Tomato", Price = 5 }, new Ingredient() { Name = "Mushrooms", Price = 7 } } }
                        );
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PizzaDataBase;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
