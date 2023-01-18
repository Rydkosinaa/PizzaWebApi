namespace DataBaseFunc.Models
{
    public class Bucket
    {
        public List<Pizza> Orders { get; set; } = new();
      
        public double Price { get; set; } = 0;
        //add
        //public void PizzaAddToOrder(Pizza pizza)
        //{
        //    this.Orders.Add(pizza);
        //    this.Price += pizza.PizzaPrice;
        //    pizza.rating++;
        //}

        //remove
        public void PizzaRemoveFromOrder(Pizza pizza)
        {
            this.Orders.Remove(pizza);
            this.Price -= pizza.PizzaPrice;
            pizza.rating--;
        }
    }
}
