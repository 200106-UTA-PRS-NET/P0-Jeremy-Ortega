using PizzaBox.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Pizza pizza = new Pizza();
            pizza.addToppings(Pizza.Toppings.cheese);
            pizza.addToppings(Pizza.Toppings.pepperoni);
            pizza.addToppings(Pizza.Toppings.sauce);
            pizza.addToppings(Pizza.Toppings.pineapple);
            pizza.addToppings(Pizza.Toppings.sausage);
            List<string> pt = pizza.getChosenToppings();
        }
    }
}
