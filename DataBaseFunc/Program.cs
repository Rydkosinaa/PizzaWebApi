using DataBaseFunc;
using Microsoft.EntityFrameworkCore;
using static DataBaseFunc.Commands;

var builder = new DbContextOptionsBuilder<PizzaContext>();
var option = builder.Options;
using (PizzaContext context = new(option))
{
    AddDefValue(option);
    foreach (var pizza in context.Pizza)

        Console.WriteLine(pizza.Name);
}