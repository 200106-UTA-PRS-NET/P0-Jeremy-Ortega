using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Mappings
{
    public class MapPizza
    {
        public static Pizza1 Map(Domain.Models.Pizza P)
        {
            return new Pizza1()
            {
                PizzaId = P.PizzaId,
                OrderId = P.OrderId,
                Toppings = P.Toppings,
                Crust = P.Crust,
                Size = P.Size
            };
        }
        public static Domain.Models.Pizza Map(Pizza1 P)
        {
            return new Domain.Models.Pizza()
            {
                PizzaId=P.PizzaId,
                OrderId=P.OrderId,
                Toppings=P.Toppings,
                Crust=P.Crust,
                Size=P.Size
            };
        }
    }
}
