using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using System.Text;
using System.Threading;


// TODO 70;


namespace PizzaBox.Storing.Repositories
{
    public class _a_SignIn
    {
        _b_LocationOrderHistory LOH;
        public _a_SignIn()
        {
            LOH = new _b_LocationOrderHistory();
        }

        /// <summary>
        /// Get through the sign in process.
        /// </summary>
        public int SignInToAccount(Dictionary<string, string> UserList, Pizza pizza, StoreRepo stores)
        {

            int choice = -1;
            while (!(choice >= 1 && choice <= 3))
            {
                Console.Clear();
                Console.WriteLine(" __________________________________");
                Console.WriteLine(" |1\tSign In?");
                Console.WriteLine(" |2\tCreate New Account?");
                Console.WriteLine(" |0\t<Close Program>");
                Console.WriteLine(" |_________________________________");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Not an int");
                    choice = -1;
                    continue;
                }

                //ask for user name and password of a previously created account 
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
                        if (userPass.Equals(password))
                        {
                        
                            // ________________________________________________
                            // TODO: ADD: <ORDER__HISTORY__GET__FROM__DATABASE>
                            //_________________________________________________

                            OrderHistory orderHistory = new OrderHistory();
                            LOH.ChooseVewOrdersOrStorePortal(username, stores, orderHistory);
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

                //ask for user to create new acount by giving a username and password 
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
                        Thread.Sleep(400);
                    }
                    // update choice to 0 to allow user to continue choosing.
                    choice = 0;
                }
                else if (choice == 0)
                {
                    break;
                }
                Console.WriteLine("choice: " + choice);
            }
            Console.WriteLine("Thank you, come again!");
            return choice;
        }
    }
}
