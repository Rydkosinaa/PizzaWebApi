using Microsoft.AspNetCore.Mvc;
using DataBaseFunc.Models;
using System.Xml.Linq;
using System.Threading.Tasks;


namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}


        public static List<Pizza> pizzas = new()
        {
            new Pizza(){ PizzaPrice =18, rating=0, Name="Margarita",PizzaIngredients={Ingredient.Cheese, Ingredient.Tomato}},
            new Pizza(){ PizzaPrice =26, rating=0, Name="Peperoni",PizzaIngredients={ Ingredient.Onion,Ingredient.Cheese, Ingredient.Tomato, Ingredient.Peperoni}},
            new Pizza(){ PizzaPrice =31, rating=0, Name="Mushroom",PizzaIngredients={ Ingredient.Mushrooms, Ingredient.Onion,Ingredient.Cheese, Ingredient.Tomato, Ingredient.Peperoni }},
            new Pizza(){ PizzaPrice =39, rating=0, Name="Mozarella",PizzaIngredients={ Ingredient.Mozarella, Ingredient.Onion,Ingredient.Cheese, Ingredient.Tomato, Ingredient.Peperoni}},
            new Pizza(){ PizzaPrice =34, rating=0, Name="Vegitariana",PizzaIngredients={ Ingredient.Mushrooms, Ingredient.Onion, Ingredient.Tomato}},

        };
        //    private static List<Ingredient> ingredients = new()
        //    {
        //    new Ingredient() {Name="Dough",Price= 10},
        //     new Ingredient() {Name="Peperoni", Price=1},
        //    new Ingredient() {Name="Onion", Price=2},
        //     new Ingredient() {Name="Cheese",Price= 3 },
        //    new Ingredient() {Name="Tomato", Price=5},
        //    new Ingredient() {Name="Mozarella", Price=15 },
        //    new Ingredient() {Name="Peper", Price=12},
        //    new Ingredient() {Name="Salad", Price=17 },
        //    new Ingredient(){Name="Salmon",Price= 17},
        //    new Ingredient(){Name="Olives",Price= 12 }
        //};

        [HttpGet]
        //public IEnumerable<Ingredient> Get() =>ingredients;
        public IEnumerable<Pizza> Get() => pizzas;
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var pizza = pizzas.SingleOrDefault(p => p.Name == name);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
        
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var pizza = pizzas.SingleOrDefault(p => p.Name == name);

            if (pizza == null)
            {
                return NotFound();
            }
            pizzas.Remove(pizza);
            return Ok();
        }

    

        //private string NextPizzaName => 
    }
}
