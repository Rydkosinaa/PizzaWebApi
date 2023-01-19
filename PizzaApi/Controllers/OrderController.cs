using Microsoft.AspNetCore.Mvc;
using DataBaseFunc.Models;
using System.Xml.Linq;
using System.Threading.Tasks;
using System;
using PizzaApi.Controllers;
using static DataBaseFunc.Commands;
using Microsoft.EntityFrameworkCore;
using DataBaseFunc;
using static Azure.Core.HttpHeader;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        static readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder<PizzaContext>();
        static readonly DbContextOptions option = builder.Options;
        public static List<Pizza> pizzas = GetMenu(option);
        public static List<Ingredient> ingredients = GetIngredients(option);

        private static Bucket bucket = new();



        [HttpGet]
        public Bucket Get() => bucket;


        private string NextPizzaName => "Custom Pizza " + Convert.ToString(bucket.Orders.Where(o => o.Name.Substring(0, 12).Equals("Custom Pizza")).Count() 
                                                                           == 0 ? 1 : bucket.Orders.Where(o => o.Name.Substring(0, 12).Equals("Custom Pizza")).Count() + 1);

        [HttpGet("GetNextName")]
        public string GetNextName()
        {
            return NextPizzaName;
        }




        [HttpPost("Add real Pizza to bucket")]
        public IActionResult Post(string Name)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Name == Name);
            if (pizza?.Name != null)
            {
                bucket.Orders.Add(pizza);
                bucket.Price += pizza.PizzaPrice;
                SetRating(option, Name);
                return CreatedAtAction(nameof(Get), new { Name = pizza.Name }, pizza);
            }
            return NotFound(new {Message = "Pizza not found"});
        }


        [HttpPost("Add Custom to Order")]
        public IActionResult Custom(List<string> IngredientName)
        {

            var pizza = new Pizza() { Name = GetNextName(), Ingredients = { ingredients.FirstOrDefault(i => i.Name == "Dough") }, PizzaPrice = 10 };
            foreach (var name in IngredientName)
            {
                if (ingredients.FirstOrDefault(i => i.Name == name)?.Name != null)
                {
                    pizza.Ingredients.Add(ingredients.FirstOrDefault(i => i.Name == name));
                    pizza.PizzaPrice += ingredients.FirstOrDefault(i => i.Name == name).Price;
                }
                else
                {
                    return NotFound(new { Message = "Ingredient not found" });
                }
            }
            bucket.Orders.Add(pizza);
            bucket.Price += pizza.PizzaPrice;
            return CreatedAtAction(nameof(Get), new { Name = pizza.Name }, pizza);
        }

        [HttpPost("Add ingredient to pizza in bucket")]
        public IActionResult AddIng(List<string> IngredientName, string pizzaName)
        {

            var pizza = bucket.Orders.FirstOrDefault(p => p.Name == pizzaName);
            if (pizza?.Name != null)
            {
                foreach (var name in IngredientName)
                {
                    if(ingredients.FirstOrDefault(i => i.Name == name)?.Name != null)
                    {
                        bucket.Orders.FirstOrDefault(p => p.Name == pizzaName).Ingredients.Add(ingredients.FirstOrDefault(i => i.Name == name));
                        bucket.Orders.FirstOrDefault(p => p.Name == pizzaName).PizzaPrice += ingredients.FirstOrDefault(i => i.Name == name).Price;
                        bucket.Price += ingredients.FirstOrDefault(i => i.Name == name).Price;
                    }
                    else
                    {
                        return NotFound(new { Message = "Ingredient not found" });
                    }
                }
                return Ok();
            }
            return NotFound(new { Message = "Pizza not found" });
        }


        [HttpDelete("Delete pizza from bucket")]
        public IActionResult Del(string pizzaName)
        {
            if (bucket.Orders.FirstOrDefault(b => b.Name == pizzaName)?.Name != null)
            {
                bucket.Price -= bucket.Orders.FirstOrDefault(b => b.Name == pizzaName).PizzaPrice;
                bucket.Orders.Remove(bucket.Orders.FirstOrDefault(b => b.Name == pizzaName));
                return Ok();
            }

            return NotFound(new { Message = "Pizza not found" });   
        }


        [HttpDelete("Delete ingredient from pizza in bucket")]
        public IActionResult DelIng(List<string> IngredientName, string pizzaName)
        {
            if (bucket.Orders.FirstOrDefault(p => p.Name == pizzaName)?.Name != null)
            {
                foreach (var name in IngredientName)
                {
                    if (bucket.Orders.FirstOrDefault(p => p.Name == pizzaName).Ingredients.FirstOrDefault(i => i.Name == name)?.Name != null)
                    {
                        bucket.Orders.FirstOrDefault(p => p.Name == pizzaName).Ingredients.Remove(ingredients.FirstOrDefault(i => i.Name == name));
                        bucket.Orders.FirstOrDefault(p => p.Name == pizzaName).PizzaPrice -= ingredients.FirstOrDefault(i => i.Name == name).Price;
                        bucket.Price -= ingredients.FirstOrDefault(i => i.Name == name).Price;
                    }
                    else
                    {
                        return NotFound(new { Message = "Ingredient not found" });
                    }
                }
                return Ok();
            }
            return NotFound(new { Message = "Pizza not found" });
        }
    }

}
