using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;

namespace PizzaApi.Controllers
{
    public class PizzaController : Controller
    {
        [Route ("api/[controller]")]
        public IActionResult Index()
        {
            return View();
        }


        private static 
        public IEnumerable<Pizza>Get()=>

    }
}
