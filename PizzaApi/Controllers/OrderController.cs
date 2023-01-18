using Microsoft.AspNetCore.Mvc;
using DataBaseFunc.Models;
using System.Xml.Linq;
using System.Threading.Tasks;
using System;
using PizzaApi.Controllers;


namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        //public IActionResult Index()
        // {
        //     return View();
        // }

        private static Order orders = new();

        [HttpGet]

        public Order Get() => orders;

        private string NextPizzaName => "Custom Pizza " + Convert.ToString(orders.orders.Count() == 0 ? 1 : orders.orders.Count() + 1);

        [HttpGet("GetNextName")]
        public string GetNextName()
        {
            return NextPizzaName;
        }

        [HttpPost]
        public IActionResult Post(Pizza order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            order.Name = NextPizzaName;
            orders.PizzaAddToOrder(order);
            return CreatedAtAction(nameof(Get), new { Name = order.Name },order);
        }
        [HttpPost("Add Custom to Order")]
        public IActionResult PostBody([FromBody] Pizza order) => Post(order);

        //[HttpPost("Add Default to Order")]
        //public IActionResult Post(string name)
        //{
            
        //    orders.PizzaAddToOrder(order);
        //    return CreatedAtAction(nameof(Get), new { Name = order.Name }, order);
        //}


    }

}
