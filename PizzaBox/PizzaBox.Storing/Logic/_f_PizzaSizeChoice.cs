﻿using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Storing.Logic
{
    public class _f_PizzaSizeChoice
    {
        _g_PizzaConfirmationToOrder PCTO;
        public _f_PizzaSizeChoice()
        {
            PCTO = new _g_PizzaConfirmationToOrder();

        }
        /// <summary>
        /// Add a preset Pizza of specified type
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PresetPizza"></param>
        /// <param name="CurOrd"></param>
        public void presetPizzaSizeChoice(string username, string storeName, Pizza PresetPizza, CurrentOrder CurOrd, bool custom)
        {
            // Get price of pizza
            int sizeOfPizza = -1;
            while (sizeOfPizza != 0)
            {
                if (!int.TryParse(Console.ReadLine(), out sizeOfPizza)) // try to read int choice
                {
                    Console.WriteLine("Not an option");
                    sizeOfPizza = -1;
                    continue;
                }
                if (sizeOfPizza == 1)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.twelveInch;
                }
                else if (sizeOfPizza == 2)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.fifteenInch;
                }
                else if (sizeOfPizza == 3)
                {
                    PresetPizza.pizzaSize = Pizza.PizzaSize.twentyInch;
                }
                else
                {
                    sizeOfPizza = -1;
                    continue;
                }

                if (custom)
                {
                }

                // if user chooses to confirm then add order.
                if (PCTO.PizzaConfirmToOrder(username, storeName, PresetPizza))
                {
                    double check = 0;
                    foreach (var priceCheck in CurOrd.pizzasInOrder)
                    {
                        check += priceCheck.getPriceOfPizza();
                    }
                    if ((check + PresetPizza.getPriceOfPizza()) > 250)
                    {
                        Console.WriteLine("This pizza will push your maximum order limit.\n " +
                            "Please check out at your earliest convenience. " +
                            "<Press any key> to return to the previous page..");
                        Console.ReadLine();
                        break;
                    }
                    // Add The pizza to the order for this restaurant and user
                    CurOrd.confirmPizzaOrder(PresetPizza, username, storeName);
                    sizeOfPizza = 0;
                }
            }
        }
    }
}
