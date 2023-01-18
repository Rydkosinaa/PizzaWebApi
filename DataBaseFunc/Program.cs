using DataBaseFunc;
using Microsoft.EntityFrameworkCore;

var builder = new DbContextOptionsBuilder<PizzaContext>();
var option = builder.Options;
using (PizzaContext context = new(option))
{

    foreach (var pizza in context.Pizza)

        Console.WriteLine(pizza.Name);
}