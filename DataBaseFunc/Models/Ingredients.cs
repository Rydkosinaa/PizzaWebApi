using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DataBaseFunc.Models
{
    public class Ingredient
    {
        [Key]
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public List<Pizza> Pizzas { get; set; } = new();
    }
}
