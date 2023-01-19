using Microsoft.AspNetCore.Mvc;
using DataBaseFunc.Models;
using System.Xml.Linq;
using System.Threading.Tasks;
using static DataBaseFunc.Commands;
using Microsoft.EntityFrameworkCore;
using DataBaseFunc;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        static readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder<PizzaContext>();
        static readonly DbContextOptions option = builder.Options;
        public static List<Pizza> pizzas = GetMenu(option);
        public static List<Ingredient> ingredients = GetIngredients(option);


        [HttpGet]
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


        [HttpGet("Sort")]
        public IEnumerable<Pizza> Sort()
        {
            var sortPizza = pizzas;
            sortPizza.Sort((p1, p2) => p1.rating.CompareTo(p2.rating));
            sortPizza.Reverse();
            return sortPizza;
        }


        [HttpGet("Ingredients")]
        public IEnumerable<Ingredient> Ingredients() => ingredients;
    }
}
