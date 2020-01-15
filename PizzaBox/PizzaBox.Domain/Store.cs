using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{
    public class Store
    {
        public string location { get; set; }
        public string storeName { get; set; }

        /// <summary>
        /// Only contain orders from this location
        /// </summary>
        public OrderHistory AllOrdersFromThisLocation;

        public Store()
        {
            // TODO: grab persisted data for this store name

            AllOrdersFromThisLocation = new OrderHistory();
        }


        public OrderHistory returnAllOrders()
        {
            return AllOrdersFromThisLocation;
        }

        /// <summary>
        /// return a list with all the orders from this store by that user.
        /// </summary>
        /// <returns></returns>
        public List<CurrentOrder> userHistoryFromThisStore(string username)
        {
            // Go through all the orders of this store.
            List<CurrentOrder> userOrdersFromLocation = new List<CurrentOrder>();

            // check each order in this stores history
            foreach(CurrentOrder OH in AllOrdersFromThisLocation.orders)
            {
                if (OH.userName == username)
                {
                    // seperat list that has all the orders for just this user
                    userOrdersFromLocation.Add(OH);

                    // Go Through All The Pizza Choices
                    foreach (Pizza pizza in OH.pizzasInOrder)
                    {
                        Console.Write("| {0} : {1} pizza with {2} crust with toppings: ", username, pizza.getSizeChoice(), pizza.getCrustChoice());

                        // Go through all the toppings on the pizza
                        foreach (string pTops in pizza.getChosenToppings())
                        {
                            Console.Write("{0}, ",pTops);
                        }
                        Console.WriteLine("::Cost:: {0}", pizza.getPriceOfPizza());
                    }
                    Console.WriteLine("| ----------------------  Total Order Cost: {0}", OH.currOrderTotal);
                    Console.WriteLine("|____________________________________________");
                    Console.WriteLine("|...");
                    Console.WriteLine("|..");         
                }
            }
            return userOrdersFromLocation;
        }




    }
}
