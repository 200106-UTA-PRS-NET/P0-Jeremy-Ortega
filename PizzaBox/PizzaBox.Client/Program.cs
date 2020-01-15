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
            List<Store>storeList = new List<Store>();
            StoreRepo stores = new StoreRepo();
            storeList = stores.currentStores;

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
                                    Console.WriteLine("|2. sign out");
                                    Console.WriteLine("__________________________________");
                                    if (!int.TryParse(Console.ReadLine(), out signedInChoice))
                                    {
                                        Console.WriteLine("Not an int");
                                        signedInChoice = -1;
                                        continue;
                                    }
                                    if (signedInChoice == 2)
                                    {
                                        Console.WriteLine("Signing Out...");
                                        Thread.Sleep(1500);
                                        break;
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
                                            foreach (Store storeLoc in storeList)
                                            {
                                                Console.WriteLine("|{0}. :  {1}", storeCount, storeLoc.storeName);
                                                Console.WriteLine("|        {0}\n", storeLoc.location);

                                                storeCount++;
                                            }
                                            Console.WriteLine("|0. :  sign out");
                                            Console.WriteLine("__________________________________________________________");
                                            if (!int.TryParse(Console.ReadLine(), out locationChoice)) // try to read int choice
                                            {
                                                Console.WriteLine("Not an int");
                                                locationChoice = -1;
                                                continue;
                                            }
                                            if (locationChoice > 0 && locationChoice <= storeList.Count)
                                            {
                                                Console.WriteLine("You've chosen: {0}", storeList[locationChoice-1].storeName);
                                                Console.WriteLine("\t\tat : {0}", storeList[locationChoice - 1].location);
                                                Thread.Sleep(1500);
                                                break;
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



    }
}
