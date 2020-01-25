using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Repositories;
using System.Threading;

namespace PizzaBox.Storing.Logic
{
    public class _f_PizzaSizeChoice
    {
        public _f_PizzaSizeChoice()
        {
        }
        /// <summary>
        /// Add a preset Pizza of specified type
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PresetPizza"></param>
        /// <param name="CurOrd"></param>
        public static void presetPizzaSizeChoice(string username, string storeName, Pizza PresetPizza, CurrentOrder CurOrd, bool custom)
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
                    // This is the crust option
                    ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
                    {
                        int crustCheck = -1;
                        while (crustCheck <1 || crustCheck >3) {
                            Console.WriteLine(" | Pizza Crust Selection.");
                            Console.WriteLine(" |---------------------------------------------------");
                            Console.WriteLine(" | 1. thin");
                            Console.WriteLine(" | 2. deep dish");
                            Console.WriteLine(" | 3. cheese filled");
                            Console.WriteLine(" |___________________________________________________");
                            
                            int crustChoice = IntCheck.IntChecker();
                            if (crustChoice == -1) { continue; }

                            if (crustChoice == 1)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.thin);
                                crustCheck = 1;
                            }
                            else if (crustChoice == 2)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.deepdish);
                                crustCheck = 1;
                            }
                            else if (crustChoice == 3)
                            {
                                PresetPizza.chooseCrust(Pizza.Crust.cheesefilled);
                                crustCheck = 1;
                            }
                            else
                            {
                                Console.WriteLine("Not an option");
                                Thread.Sleep(1100);
                            }
                        }
                    }
                        // This is the toppings choice.
                    List<string> toppings = new List<string>();
                    List<string> fullTops = new List<string>();
                    
                    fullTops.Add("sauce");
                    fullTops.Add("cheese");
                    fullTops.Add("pepperoni");
                    fullTops.Add("sausage");
                    fullTops.Add("pineapple");

                    for (int i = 0; i < 5; i++)
                    {
                        ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);
                        if (toppings.Count == 0)
                        {
                            Console.WriteLine(" | You may choose up to five toppings.. Hit enter after each submission.");
                            Console.WriteLine(" |---------------------------------------------------");
                        }
                        else
                        {
                            Console.Write(" | ");
                        }
                        foreach (var top in toppings)
                        {
                            Console.Write($" <{top}>");
                        }
                        if (toppings.Count > 0) {
                            Console.WriteLine();
                        }
                        int count = 0;
                        foreach (var fTop in fullTops) {
                            Console.WriteLine($" | {count+1}. {fTop}");
                            count++;
                        }

                        Console.WriteLine(" | 0. [COMPLETED TOPPING CHOICE]...");
                        Console.WriteLine(" |______________________________________________________");
                       
                        int toppingChoice = IntCheck.IntChecker();
                        if (toppingChoice == -1 || toppingChoice > fullTops.Count) {
                            i--;
                            continue; 
                        }
                        if (toppingChoice == 0)
                        {
                            break;
                        }

                        // remove from remaining toppings for customer 
                        string temp = fullTops[toppingChoice - 1];
                        fullTops.RemoveAt(toppingChoice - 1);
                        toppings.Add(temp);

                    }
                    foreach(var tops in toppings)
                    {
                        if (tops.Equals("sauce"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.sauce);
                        }
                        else if (tops.Equals("cheese"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.cheese);
                        }
                        else if (tops.Equals("pepperoni"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.pepperoni);
                        }
                        else if (tops.Equals("sausage"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.sausage);
                        }
                        else if (tops.Equals("pineapple"))
                        {
                            PresetPizza.addToppings(Pizza.Toppings.pineapple);
                        }
                    }
                }

                // if user chooses to confirm then add order.
                if (_g_PizzaConfirmationToOrder.PizzaConfirmToOrder(username, storeName, PresetPizza))
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
                else
                {
                    sizeOfPizza = 0;
                }
            }
        }
    }
}
