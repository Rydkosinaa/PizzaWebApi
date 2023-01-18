namespace PizzaApi.Models
{
    public class Order
    {
        public List<Pizza> orders { get; set; } = new List<Pizza>() ;
      
        public double price { get; set; } = 0;
        //add
        public void PizzaAddToOrder(Pizza pizza)
        {
            this.orders.Add(pizza);
            this.price += pizza.PizzaPrice;
            pizza.rating++;
        }

        //remove
        public void PizzaRemoveFromOrder(Pizza pizza)
        {
            this.orders.Remove(pizza);
            this.price -= pizza.PizzaPrice;
            pizza.rating--;
        }
    }
}
