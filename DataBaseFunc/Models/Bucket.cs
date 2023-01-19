namespace DataBaseFunc.Models
{
    public class Bucket
    {
        public List<Pizza> Orders { get; set; } = new();
      
        public double Price { get; set; } = 0;
    }
}
