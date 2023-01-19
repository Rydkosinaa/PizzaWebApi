using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFunc.Models
{
    public class PizzaIngridient
    {
        public string PizzaName { get; set; } = null!;
        public Pizza? Pizza { get; set; }

        public string IngName { get; set; } = null!;
        public  Ingredient? Ingredient { get; set; }
    }
}
