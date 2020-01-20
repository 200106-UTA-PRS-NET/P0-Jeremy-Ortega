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
        public int Crust { get; set; }
        public int Size { get; set; }
    }
}
