using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using System.Text;
using System.Threading;
using PizzaBox.Storing.TestModels;


// TODO 70;


namespace PizzaBox.Storing.Logic
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
        //public int SignInToAccount(Dictionary<string, string> UserList, Pizza pizza, StoreRepository stores,
        public int SignInToAccount(
            Abstractions.IRepositoryCustomer<Customer1> repo,
            Abstractions.IRepositoryOrders<Order1> orderRepo,
            Abstractions.IRepositoryPizza<Pizza1> pizzaRepo,
            Abstractions.IRepositoryStore<Store1> storeRepo)
        {   

            var customers = repo.ReadInCustomer();
            

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

                    // email
                    Console.Clear();
                    Console.WriteLine(" ---- email ----");
                    string email = Console.ReadLine();

                    // password
                    Console.Clear();
                    Console.WriteLine(" ---- password ----");
                    string password = Console.ReadLine();

                    string name = "";
                    bool correctAuth = false;
                    foreach (var Cx in customers){
                        if (Cx.Username != null && Cx.Username.Equals(email))
                        {
                            if (Cx.UserPass.Equals(password))
                            {
                                name = Cx.Fname;
                                correctAuth = true;
                            }
                        }
                    }
                    if (!correctAuth)
                    {
                        Console.Clear();
                        Console.WriteLine("No User found with that email and password.");
                        Thread.Sleep(1700);
                        continue;
                    }

                    //// check if dictionary contains the key, then if the password is the same as the key.
                    //if (UserList.ContainsKey(email))
                    //{
                    //    // retrieve the value from the dictionary using the key.
                    //    string userPass = UserList[email];

                    //    // Check that the password matches the previously created email.
                    //    if (userPass.Equals(password))
                    //    {
                        
                    //        // ________________________________________________
                    //        // TODO: ADD: <ORDER__HISTORY__GET__FROM__DATABASE>
                    //        //_________________________________________________

                    ///////////////// remove following line /////////////////////
                    //OrderHistory orderHistory = new OrderHistory();
                    //LOH.ChooseVewOrdersOrStorePortal(name, stores, orderHistory, repo, orderRepo);

                    LOH.ChooseVewOrdersOrStorePortal(email, repo, orderRepo, pizzaRepo, storeRepo);

                    //    }

                    //    // Else return the prompt that they weren't found in the system.
                    //    else
                    //    {
                    //        Console.WriteLine("An account isn't found with that email and password.");
                    //    }
                    //}
                    // Respond if the email wasn't found.  Using the same string as above to relay ambiguity
                    // between whether it was the email or password that wasn't found.
                    //else
                    //{
                    //    Console.WriteLine("An account isn't found with that email and password.");
                    //}
                    // allow loggin loop to continue;
                    choice = 0;
                }

                //ask for user to create new acount by giving a email and password 
                else if (choice == 2)
                {
                    // email - maps to username in the database
                    Console.Clear();
                    Console.WriteLine(" ---- new email ---- ");
                    string email = Console.ReadLine();

                    // password
                    Console.WriteLine("\n ---- create password ----");
                    string password = Console.ReadLine();

                    // First Name
                    Console.WriteLine("\n ---- first name ----");
                    string fname = Console.ReadLine();

                    // Last Name
                    Console.WriteLine("\n ---- last name ----");
                    string lname = Console.ReadLine();

                    // Phone Number
                    Console.WriteLine("\n ---- Phone ----");
                    string phone = Console.ReadLine();

                    bool correctAuth = false;
                    foreach (var Cx in customers)
                    {
                        if (Cx.Username!=null && Cx.Username.Equals(email))
                            if (Cx.UserPass.Equals(password))
                                correctAuth = true;
                    }
                    if (correctAuth)
                    {
                        Console.Clear();
                        Console.WriteLine("Email already in use please sign in or use another email address.");
                        Thread.Sleep(1700);
                        continue;
                    }
                    /*
                    //// check if dictionary contains the key, then if the password is the same as the key.
                    //if (UserList.ContainsKey(email))
                    //{
                    //    // retrieve the value from the dictionary using the key.
                    //    string userPass = UserList[email];

                    //    // Check that the password matches the previously created email.
                    //    if (userPass.Equals(password))
                    //    {
                    //        Console.Clear();
                    //        Console.WriteLine("An account already matches that email: would you like to try logging in?");
                    //        Thread.Sleep(1000);
                    //    }
                    //}

                    //// Respond if the email wasn't found.  Using the same string as above to relay ambiguity
                    //// between whether it was the email or password that wasn't found.
                    //else
                    //{
                    */
                        Console.Clear();
                        Console.WriteLine("Created your account! [{0}]", email);

                        

                        Customer1 Cu = new Customer1()
                        {
                            Fname = fname,
                            Lname = lname,
                            Username = email,
                            UserPass = password,
                            Phone = Convert.ToInt32(phone)
                        };

                        repo.CreateCustomer(Cu);

                        //UserList.Add(email, password);
                        Thread.Sleep(400);
                    //}
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
