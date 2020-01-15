using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{
    public class CurrentOrder
    {
        public List<Pizza> pizzasInOrder;
        public string userName { get; set; }
        public string storeName { get; set; }
        public double currOrderTotal { get; set; }

        public CurrentOrder()
        {
            pizzasInOrder = new List<Pizza>();
        }

        public CurrentOrder returnCompletedOrder()
        {
            return this;
        }

        /// <summary>
        /// Confirm The pizza order and add the running current total.
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="username"></param>
        /// <param name="storename"></param>
        public void confirmPizzaOrder(Pizza pizza, string username, string storename)
        {
            this.userName = username;
            this.pizzasInOrder.Add(pizza);
            this.storeName = storename;
            currOrderTotal += pizza.getPriceOfPizza();

            // Persist the Order
        }


    }
}
