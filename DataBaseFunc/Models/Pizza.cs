using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DataBaseFunc.Models
{
    public class Pizza
    {

        public double PizzaPrice { get; set; }
        public int rating { get; set; } = 0;
        [Key]
        public string Name { get; set; } = "Custom pizza";

        public List<PizzaIngridient> PizzaIngridients { get; set; } = new();

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

}
