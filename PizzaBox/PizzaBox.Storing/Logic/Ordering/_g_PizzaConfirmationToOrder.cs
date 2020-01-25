using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing.Logic.Portal;

namespace PizzaBox.Storing.Logic.Ordering
{
    public class _g_PizzaConfirmationToOrder
    {
        public _g_PizzaConfirmationToOrder()
        {
        }
        /// <summary>
        /// Allow the user an opportunity to back out of a pizza, not the entire order.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="HawaiiPizza"></param>
        /// <returns></returns>
        public static bool PizzaConfirmToOrder(string username, string storeName, Pizza PizzaChoice)
        {
            int confirm = -1;
            while (!(confirm >= 1 && confirm <= 2))
            {
                ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
                Console.WriteLine(" | %%% Price of pizza adding to order: ${0} %%%|", PizzaChoice.getPriceOfPizza());
                Console.WriteLine(" |---------------------------------------------------------");
                Console.WriteLine(" |1. : Confirm Pizza to order");
                Console.WriteLine(" |2. : return to previous menu...");
                Console.WriteLine(" |_________________________________________________________");

                confirm = IntCheck.IntChecker();
                if (confirm == -1) { continue; }

                if (confirm == 1)
                {
                    return true;
                }
                if (confirm == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Not an option");
                    confirm = -1;
                }
            }
            return false;
        }
    }
}
