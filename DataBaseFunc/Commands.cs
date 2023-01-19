using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DataBaseFunc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
namespace DataBaseFunc
{
    public class Commands
    {
        static public void AddDefValue(DbContextOptions context)
        {
            using PizzaContext commands = new(context);
            var Dough = new Ingredient() { Name = "Dough", Price = 10 };
            var Peperonis = new Ingredient() { Name = "Peperonis", Price = 1 };
            var Onion = new Ingredient() { Name = "Onion", Price = 2 };
            var Cheese = new Ingredient() { Name = "Cheese", Price = 3 };
            var Tomato = new Ingredient() { Name = "Tomato", Price = 5 };
            var Mushrooms = new Ingredient() { Name = "Mushrooms", Price = 7 };
            var Mozarellas = new Ingredient() { Name = "Mozarella", Price = 15 };
            var Peper = new Ingredient() { Name = "Peper", Price = 12 };
            var Salad = new Ingredient() { Name = "Salad", Price = 17 };
            var Salmon = new Ingredient() { Name = "Salmon", Price = 17 };
            var Olives = new Ingredient() { Name = "Olives", Price = 12 };

            commands.Ingredients.AddRange(Dough, Peperonis, Onion, Cheese, Tomato, Mushrooms, Mozarellas, Peper, Salad, Salmon, Olives);

            var Margarita = new Pizza() { PizzaPrice = 18, Name = "Margarita" };
            var Peperoni = new Pizza() { PizzaPrice = 26, rating = 0, Name = "Peperoni" };
            var Mushroom = new Pizza() { PizzaPrice = 31, rating = 0, Name = "Mushroom" };

            commands.Pizza.AddRange(Margarita, Peperoni, Mushroom);

            Margarita.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Tomato });
            Margarita.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Cheese });
            Margarita.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Dough });
            Margarita.Ingredients.Add(Tomato);
            Margarita.Ingredients.Add(Cheese);
            Margarita.Ingredients.Add(Dough);

            Peperoni.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Onion });
            Peperoni.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Peperonis });
            Peperoni.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Tomato });
            Peperoni.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Cheese });
            Peperoni.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Dough });
            Peperoni.Ingredients.Add(Onion);
            Peperoni.Ingredients.Add(Peperonis);
            Peperoni.Ingredients.Add(Tomato);
            Peperoni.Ingredients.Add(Cheese);
            Peperoni.Ingredients.Add(Dough);

            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Mushrooms });
            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Onion });
            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Peperonis });
            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Tomato });
            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Cheese });
            Mushroom.PizzaIngridients.Add(new PizzaIngridient { Ingredient = Dough });
            Mushroom.Ingredients.Add(Mushrooms);
            Mushroom.Ingredients.Add(Onion);
            Mushroom.Ingredients.Add(Peperonis);
            Mushroom.Ingredients.Add(Tomato);
            Mushroom.Ingredients.Add(Cheese);
            Mushroom.Ingredients.Add(Dough);

            commands.SaveChanges();
        }
    }
}
