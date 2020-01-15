using System;
using System.Collections.Generic;
using System.Threading;
using PizzaBox.Domain;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
    class Program
    {

        static void Main(string[] args)
        {
          
            // Sign In 
            int choice = SignIn();
            Thread.Sleep(1400);
        }


        /// <summary>
        /// Get through the sign in process.
        /// </summary>
        private static int SignIn()
        {
            // Initialize the main data structures going to be handling the pertinant selection data
            StoreRepo stores = new StoreRepo();
            
            Pizza pizza = new Pizza();


            int choice = -1;
            Dictionary<string, string> UserList = new Dictionary<string, string>();
            while (!(choice >=1 && choice <=3))
            {
                Console.Clear();
                Console.WriteLine("__________________________________");
                Console.WriteLine("|1\tSign In?");
                Console.WriteLine("|2\tCreate New Account?");
                Console.WriteLine("|0\t<Close Program>");
                Console.WriteLine("__________________________________");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Not an int");
                    choice = -1;
                    continue;
                }
                else
                {

                    /*
                     * ask for user name and password of a previously created account 
                     */
                    if (choice == 1)
                    {
                        // username
                        Console.Clear();
                        Console.WriteLine(" ---- username ----");
                        string username = Console.ReadLine();

                        // password
                        Console.Clear();
                        Console.WriteLine(" ---- password ----");
                        string password = Console.ReadLine();


                        // check if dictionary contains the key, then if the password is the same as the key.
                        if (UserList.ContainsKey(username))
                        {
                            // retrieve the value from the dictionary using the key.
                            string userPass = UserList[username];

                            // Check that the password matches the previously created username.
                            if (userPass.Equals(password)) {
                                int signedInChoice = 0;
                                while (signedInChoice != 3) {
                                    Console.Clear();
                                    Console.WriteLine("__________________________________");
                                    Console.WriteLine("| Hello:\t[" + username + "]");
                                    Console.WriteLine("|---------------------------------");
                                    Console.WriteLine("|1. Choose Location");
                                    Console.WriteLine("|2. Look at my order history. ");
                                    Console.WriteLine("|3. sign out");
                                    Console.WriteLine("|_________________________________");
                                    if (!int.TryParse(Console.ReadLine(), out signedInChoice))
                                    {
                                        Console.WriteLine("Not an int");
                                        signedInChoice = -1;
                                        continue;
                                    }
                                    if (signedInChoice == 3)
                                    {
                                        Console.WriteLine("Signing Out...");
                                        Thread.Sleep(1500);
                                        break;
                                    }

                                    // Look at order history
                                    if (signedInChoice == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("__________________________________________________________");
                                        Console.WriteLine("| Hello:\t[" + username + "]");
                                        Console.WriteLine("|---------------------------------------------------------");
                                        Console.WriteLine("| ... Order history ...");
                                        Console.WriteLine("|_________________________________________________________");
                                    }
                                    /*
                                     * This choice signifies selecting the pizza parlor you wish to engage with 
                                     */
                                    if (signedInChoice == 1)
                                    {
                                        int locationChoice = -1;
                                        while (locationChoice != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("__________________________________________________________");
                                            Console.WriteLine("| Hello:\t[" + username + "]");
                                            Console.WriteLine("|---------------------------------------------------------");
                                            Console.WriteLine("| Select a Pizza Parlor Location");
                                            Console.WriteLine("|_________________________________________________________");
                                            int storeCount = 1;

                                            // read through the list of Pizza parlors available.
                                            foreach (Store storeLoc in stores.currentStores)
                                            {
                                                Console.WriteLine("|{0}. :  {1}", storeCount, storeLoc.storeName);
                                                Console.WriteLine("|        {0}\n", storeLoc.location);

                                                storeCount++;
                                            }
                                            Console.WriteLine("|0. :  sign out");
                                            Console.WriteLine("|_________________________________________________________");
                                            if (!int.TryParse(Console.ReadLine(), out locationChoice)) // try to read int choice
                                            {
                                                Console.WriteLine("Not an int");
                                                locationChoice = -1;
                                                continue;
                                            }

                                            // choose location and bring up data about that location
                                            if (locationChoice > 0 && locationChoice <= stores.currentStores.Count)
                                            {
                                                int inStoreChoice = -1;
                                                while (inStoreChoice != 0) {
                                                    Console.Clear();
                                                    Console.WriteLine("__________________________________________________________");
                                                    Console.WriteLine("| Hello:\t[" + username + "]");
                                                    Console.WriteLine("|---------------------------------------------------------");
                                                    Console.WriteLine("| {0}", stores.currentStores[locationChoice - 1].storeName);
                                                    Console.WriteLine("|_________________________________________________________");
                                                    Console.WriteLine("| 1. : Order a Pizza.");
                                                    Console.WriteLine("| 2. : Preview current order. ");
                                                    Console.WriteLine("| 3. : Preview your history of orders at this location.");
                                                    Console.WriteLine("| 0  : Return to Restaurant choice.");
                                                    Console.WriteLine("|_________________________________________________________");
                                                    Thread.Sleep(1500);

                                                    if (!int.TryParse(Console.ReadLine(), out inStoreChoice)) // try to read int choice
                                                    {
                                                        Console.WriteLine("Not an int");
                                                        inStoreChoice = -1;
                                                        continue;
                                                    }

                                                    // Pizza Size
                                                    if(inStoreChoice == 1)
                                                    {
                                                        int presetPizzaOptional = -1;
                                                        while (presetPizzaOptional != 0) {
                                                            Console.Clear();
                                                            Console.WriteLine("__________________________________________________________");
                                                            Console.WriteLine("| Hello:\t[" + username + "]");
                                                            Console.WriteLine("|---------------------------------------------------------");
                                                            Console.WriteLine("| {0}", stores.currentStores[locationChoice - 1].storeName);
                                                            Console.WriteLine("|_________________________________________________________");
                                                            Console.WriteLine("|  :: Choose Pizza Size ::");
                                                            Console.WriteLine("| 1. : Hawaiian");
                                                            Console.WriteLine("| 2. : Meat Lovers");
                                                            Console.WriteLine("| 3  : Pepperoni");
                                                            Console.WriteLine("| 4. : [MAKE YOUR OWN]");
                                                            Console.WriteLine("| 0  : return to previous page...");
                                                            Console.WriteLine("|_________________________________________________________");

                                                            if (!int.TryParse(Console.ReadLine(), out presetPizzaOptional)) // try to read int choice
                                                            {
                                                                Console.WriteLine("Not an int");
                                                                presetPizzaOptional = -1;
                                                                continue;
                                                            }
                                                            if (presetPizzaOptional == 4) {
                                                                printPizzaSizeChoice(username, stores, locationChoice, "[CUSTOM PIZZA]");
                                                            }

                                                            // Customer chose Hawaiian preset pizza.
                                                            else if (presetPizzaOptional == 1)
                                                            {
                                                                printPizzaSizeChoice(username, stores, locationChoice, "Hawaiian Pizza");
                                                                Pizza HawaiiPizza = new Pizza(); // Comes with sauce and Cheese
                                                                HawaiiPizza.addToppings(Pizza.Toppings.pineapple);
                                                                HawaiiPizza.chooseCrust(Pizza.Crust.deepdish);
                                                                CurrentOrder CurOrd = new CurrentOrder();
                                                                Console.WriteLine("CHECK HERE");
                                                                Thread.Sleep(2000);

                                                                // Get price of pizza
                                                                int sizeOfPizza = -1;
                                                                while (sizeOfPizza != 0) {
                                                                    if (!int.TryParse(Console.ReadLine(), out sizeOfPizza)) // try to read int choice
                                                                    {
                                                                        Console.WriteLine("Not an int");
                                                                        sizeOfPizza = -1;
                                                                        continue;
                                                                    }
                                                                    if (sizeOfPizza == 1)
                                                                    {
                                                                        HawaiiPizza.pizzaSize = Pizza.PizzaSize.twelveInch;
                                                                    }
                                                                    else if (sizeOfPizza == 2)
                                                                    {
                                                                        HawaiiPizza.pizzaSize = Pizza.PizzaSize.fifteenInch;
                                                                    }
                                                                    else if (sizeOfPizza == 3)
                                                                    {
                                                                        HawaiiPizza.pizzaSize = Pizza.PizzaSize.twentyInch;
                                                                    }

                                                                    // if user chooses to confirm then add order.
                                                                    if(sizeConfirmation(username, stores, locationChoice, HawaiiPizza))
                                                                    {
                                                                        CurOrd.confirmPizzaOrder(HawaiiPizza, username, stores.currentStores[locationChoice - 1].storeName);
                                                                        sizeOfPizza = 0;
                                                                    }
                                                                }
                                                            }
                                                            else if (presetPizzaOptional == 2)
                                                            {
                                                                printPizzaSizeChoice(username, stores, locationChoice, "Meat Lovers");
                                                            }
                                                            else if (presetPizzaOptional == 3)
                                                            {
                                                                printPizzaSizeChoice(username, stores, locationChoice, "Pepperoni");
                                                            }
                                                        }
                                                    }
                                                    if (inStoreChoice == 2)
                                                    {

                                                    }
                                                    // Look at previous order history at current location
                                                    if (inStoreChoice == 3)
                                                    {
                                                        OrderHistory StoresOrdHist = null;
                                                        StoresOrdHist.orders = stores.currentStores[locationChoice-1].userHistoryFromThisStore(username);
                                                        Console.Clear();
                                                        Console.WriteLine("__________________________________________________________");
                                                        Console.WriteLine("| Hello:\t[" + username + "]");
                                                        Console.WriteLine("|---------------------------------------------------------");
                                                        Console.WriteLine("| {0}", stores.currentStores[locationChoice - 1].storeName);
                                                        Console.WriteLine("|_________________________________________________________");
                                                        Console.WriteLine("| ::Orders::");
                                                        StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
                                                        Console.WriteLine("|_________________________________________________________");
                                                        Console.ReadLine();
                                                    }

                                                    if(inStoreChoice == 0)
                                                    {
                                                        Console.WriteLine("returning to the previous page...");
                                                        Thread.Sleep(700);
                                                        break;
                                                    } 
                                                }
                                                
                                            }
                                            if (locationChoice == 0)
                                            {
                                                Console.WriteLine("returning to the previous page...");
                                                Thread.Sleep(700);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            // Else return the prompt that they weren't found in the system.
                            else
                            {
                                Console.WriteLine("An account isn't found with that username and password.");
                            }
                        }
                        // Respond if the username wasn't found.  Using the same string as above to relay ambiguity
                        // between whether it was the username or password that wasn't found.
                        else
                        {
                            Console.WriteLine("An account isn't found with that username and password.");
                        }
                        // allow loggin loop to continue;
                        choice = 0;
                    }



                    /*
                     * ask for user to create new acount by giving a username and password 
                     */
                    else if (choice == 2)
                    {
                        // username
                        Console.Clear();
                        Console.WriteLine(" ---- new username ---- ");
                        string username = Console.ReadLine();

                        // password
                        Console.Clear();
                        Console.WriteLine(" ---- new password ----");
                        string password = Console.ReadLine();

                        // check if dictionary contains the key, then if the password is the same as the key.
                        if (UserList.ContainsKey(username))
                        {
                            // retrieve the value from the dictionary using the key.
                            string userPass = UserList[username];

                            // Check that the password matches the previously created username.
                            if (userPass.Equals(password))
                            {
                                Console.Clear();
                                Console.WriteLine("An account already matches that username: would you like to try logging in?");
                                Thread.Sleep(1000);
                            }

                        }
                        // Respond if the username wasn't found.  Using the same string as above to relay ambiguity
                        // between whether it was the username or password that wasn't found.
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Created your account! [{0}]", username);
                            UserList.Add(username, password);
                            Thread.Sleep(500);
                        }
                        // update choice to 0 to allow user to continue choosing.
                        choice = 0;
                    }
                    else if (choice == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("choice: "+choice);
            }
            Console.WriteLine("Thank you, come again!");
            return choice;
        }

        /// <summary>
        /// Print the size options for a pizza
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="PizzaType"></param>
        public static void printPizzaSizeChoice(string username, StoreRepo stores, int locationChoice, string PizzaType)
        {
            Console.Clear();
            Console.WriteLine("__________________________________________________________");
            Console.WriteLine("| Hello:\t[" + username + "]");
            Console.WriteLine("|---------------------------------------------------------");
            Console.WriteLine("| {0}", stores.currentStores[locationChoice - 1].storeName);
            Console.WriteLine("|_________________________________________________________");
            Console.WriteLine("|  :: {0} ::", PizzaType);
            Console.WriteLine("| 1. : 12\"");
            Console.WriteLine("| 2. : 15\"");
            Console.WriteLine("| 3  : 20\"");
            Console.WriteLine("| 0  : return to previous page...");
            Console.WriteLine("|_________________________________________________________");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Allow the user an opportunity to back out of a pizza, not the entire order.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="HawaiiPizza"></param>
        /// <returns></returns>
        public static bool sizeConfirmation(string username, StoreRepo stores, int locationChoice, Pizza HawaiiPizza)
        {
            Console.WriteLine("CHECK");
            int confirm = -1;
            while (!(confirm >=1 && confirm <=2)) {
                Console.Clear();
                Console.WriteLine("__________________________________________________________");
                Console.WriteLine("| Hello:\t[" + username + "]");
                Console.WriteLine("|---------------------------------------------------------");
                Console.WriteLine("| {0}", stores.currentStores[locationChoice - 1].storeName);
                Console.WriteLine("|_________________________________________________________");
                Console.WriteLine("| Price of Pizza: {0}", HawaiiPizza.getPriceOfPizza());
                Console.WriteLine("|1. : Confirm Order");
                Console.WriteLine("|2. : return to previous menu...");
                Console.WriteLine("|_________________________________________________________");
                if (!int.TryParse(Console.ReadLine(), out confirm)) // try to read int choice
                {
                    Console.WriteLine("Not an int");
                    confirm = -1;
                    continue;
                }
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
