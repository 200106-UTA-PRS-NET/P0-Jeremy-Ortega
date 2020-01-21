using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.TestModels
{
    public class Pizza1
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int Toppings { get; set; }
        public string Crust { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
