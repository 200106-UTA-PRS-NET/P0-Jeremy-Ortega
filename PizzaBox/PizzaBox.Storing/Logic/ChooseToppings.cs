using PizzaBox.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic
{
    public class ChooseToppings
    {
        public List<Pizza.Toppings> TAL { get; set; }
        public ChooseToppings()
        {
            TAL = new List<Pizza.Toppings>();
        }
    }
}
