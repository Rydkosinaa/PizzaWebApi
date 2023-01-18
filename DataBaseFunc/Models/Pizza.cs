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

        
        public List<Ingredient> PizzaIngredients { get; set; } = new List<Ingredient>()
        {
              new Ingredient () {Name = "Dough", Price = 10}
        };

        

        //public void AddIngredient(Ingredient ingredient)
        //{

        //    this.PizzaIngredients.Add(ingredient);
        //    this.PizzaPrice += ingredient.Price;
        //}

        //public bool RemoveIngredient(Ingredient ingredient)
        //{
        //    this.PizzaPrice -= ingredient.Price;
        //    return this.PizzaIngredients.Remove(ingredient);
        //    //this.PizzaIngredients.Remove(ingredient);
        //    //this.PizzaPrice -= ingredient.Price;
        //    //return this.PizzaPrice;
        //}


    }

}
