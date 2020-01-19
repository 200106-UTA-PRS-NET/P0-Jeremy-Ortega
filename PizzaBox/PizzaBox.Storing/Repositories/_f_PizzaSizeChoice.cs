﻿using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
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
        public void presetPizzaSizeChoice(string username, StoreRepo stores, int locationChoice, Pizza PresetPizza, CurrentOrder CurOrd)
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

                // if user chooses to confirm then add order.
                if (PCTO.PizzaConfirmToOrder(username, stores, locationChoice, PresetPizza))
                {
                    // Add The pizza to the order for this restaurant and user
                    CurOrd.confirmPizzaOrder(PresetPizza, username, stores.currentStores[locationChoice - 1].storeName);
                    // currentOrder.EnterNewCompletedOrder(CurOrd);
                    sizeOfPizza = 0;
                }
            }
        }
    }
}