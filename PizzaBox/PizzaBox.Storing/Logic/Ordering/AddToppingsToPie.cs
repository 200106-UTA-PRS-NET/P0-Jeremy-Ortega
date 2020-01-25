using PizzaBox.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic.Ordering
{
    class AddToppingsToPie
    {
        public static char[] getAddToppingsToPie(Pizza pie)
        {
            char[] tops = new char[5];
            var top = pie.getChosenToppings();

            if (top.Contains("sauce"))
            {
                tops[0] = '1';
            }
            else
            {
                tops[0] = '0';
            }
            if (top.Contains("cheese"))
            {
                tops[1] = '1';
            }
            else
            {
                tops[1] = '0';
            }
            if (top.Contains("pepperoni"))
            {
                tops[2] = '1';
            }
            else
            {
                tops[2] = '0';
            }
            if (top.Contains("sausage"))
            {
                tops[3] = '1';
            }
            else
            {
                tops[3] = '0';
            }
            if (top.Contains("pineapple"))
            {
                tops[4] = '1';
            }
            else
            {
                tops[4] = '0';
            }
            return tops;
        }
    }
}
