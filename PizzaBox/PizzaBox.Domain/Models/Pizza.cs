using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int Toppings { get; set; }
        public int Crust { get; set; }
        public int Size { get; set; }

        public virtual CxOrder Order { get; set; }
    }
}
