namespace PizzaApi.Models
{
    public class Menu
    {

        //static public Pizza Margarita = new Pizza(new List<Ingredient>() { Ingredient.Cheese, Ingredient.Tomato }, "Margarita");
        //static public Pizza Peperoni = new Pizza(new List<Ingredient>() { Ingredient.Cheese, Ingredient.Tomato, Ingredient.Peperoni }, "Peperoni");
        //static public Pizza Mozarella = new Pizza(new List<Ingredient>() { Ingredient.Mozarella, Ingredient.Tomato, Ingredient.Peperoni }, "Mozarella");
        //static public Pizza Vegetarian = new Pizza(new List<Ingredient>() { Ingredient.Tomato, Ingredient.Olives, Ingredient.Salad }, "Vegetarian");

        public List<Pizza> PizzaMenu = new List<Pizza>();

        public Pizza GetPizza(string name)
        {
            foreach (var p in PizzaMenu)
            {
                if (p.Name == name)
                    return p;
            }
            return null;
        }


        public List<Pizza> SortByRating()
        {
            PizzaMenu.Sort((p1, p2) => p2.rating.CompareTo(p1.rating));
            return PizzaMenu;
        }
    }
}
