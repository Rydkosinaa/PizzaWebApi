namespace PizzaApi.Models
{
    public class Pizza
    {

        public double PizzaPrice { get; set; }/* = Ingredient.Dough.Price*/
        public int rating = 0;
        public string Name = "Custom pizza";


       //public List<Ingredient> PizzaIngredients = new List<Ingredient>()
       //{
       //      Ingredient.Dough
       //};

        //public Pizza(List<Ingredient> pizzaIngredients, string name)
        //{
        //    Name = name;
        //    foreach (var ingredient in pizzaIngredients)
        //    {
        //        PizzaIngredients.Add(ingredient);
        //        PizzaPrice += ingredient.Price;
        //    }
        //}

        //public Pizza(Ingredient pizzaIngredient)
        //{

        //    PizzaIngredients.Add(pizzaIngredient);
        //    PizzaPrice += pizzaIngredient.Price;

        //}

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
