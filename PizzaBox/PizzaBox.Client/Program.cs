using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;


namespace PizzaBox.Client
{
    
    public class Program
    {


        public Program()
        {

        }

        public static void Main(string[] args)
        {
            // Initialize the main data structures going to be handling the pertinant selection data
            StoreRepo stores = new StoreRepo();
            Pizza pizza = new Pizza();
            Dictionary<string, string> UserList = new Dictionary<string, string>();
            _a_SignIn SI = new _a_SignIn();
            // Sign In 

            var repo = Dependencies.CreateCustomerRepository();
            // var customer = repo.ReadInCustomer();

            int choice = SI.SignInToAccount(UserList, pizza, stores, repo);

            //Storing.Abstractions.IRepositoryCustomer<Customer1> repo




            //foreach (var Cx in customer)
            //{
            //    if(Cx.Fname != "" || Cx.Fname != null)
            //        Console.WriteLine($"{Cx.Fname} {Cx.Lname}");
            //}
            //Console.ReadLine();


            // // Works just need to stop creating new 
            //Customer1 Cu = new Customer1()
            //{
            //    Fname = "Jeremy",
            //    Lname = "Ortega",
            //    Username = "jmastaice",
            //    UserPass = "1",
            //    Phone = 1234561117
            //};

            //repo.CreateCustomer(Cu);


            //// Update Works - will need to delete all references to Cx Id in other tables before finally deleting this 
            //// row. 
            //Customer1 cu2 = new Customer1()
            //{
            //    Fname = "JMaStAiCe",
            //    Id = 12,
            //};
            //repo.UpdateCustomer(cu2);
            //Console.ReadLine();

            //// Deletion Works
            //repo.DeleteCustomer(12);



            //CustomerRepository CR = new CustomerRepository();

            Thread.Sleep(1500);
        }

    
    }


}
/*
/////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Get through the sign in process.
/// </summary>
private static int SignIn(Dictionary<string, string> UserList, Pizza pizza, StoreRepo stores)
{

    int choice = -1;
    while (!(choice >=1 && choice <=3))
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
                    ChooseStoreOrSignOut(username, stores);
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
        Console.WriteLine("choice: "+choice);
    }
    Console.WriteLine("Thank you, come again!");
    return choice;
}



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// May keep this page for added functionality later, Possibly have a store owner special option or add some other functionality.
/// Possibly stats on when you last visited certain stores.
/// Choose store locations - probably remove this implementation in favor of just having the user go directly to choosing Locations
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
public static void ChooseStoreOrSignOut(string username, StoreRepo stores)
{
    int signedInChoice = 0;
    while (signedInChoice != 3)
    {
        Console.Clear();
        Console.WriteLine(" __________________________________");
        Console.WriteLine(" | Hello:\t[" + username + "]");
        Console.WriteLine(" |---------------------------------");
        Console.WriteLine(" |1. Choose Location");
        // Console.WriteLine(" |2. Look at my order history. "); ignore until rest of project finished
        Console.WriteLine(" |2. sign out");
        Console.WriteLine(" |_________________________________");
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

        // Look at order history ignore functionality until rest of project is finished and maybe add at end
        // for now we only want a Cx to access their orders once signed into a location.
        /*
        if (signedInChoice == 2)
        {
            Console.Clear();
            Console.WriteLine(" __________________________________________________________");
            Console.WriteLine(" | Hello:\t[" + username + "]");
            Console.WriteLine(" |---------------------------------------------------------");
            Console.WriteLine(" | ... Order history ...");
            Console.WriteLine(" |_________________________________________________________");
        }


         // This choice signifies selecting the pizza parlor you wish to engage with 

        if (signedInChoice == 1)
        {
            choosePizzaStoreLocation(username, stores);
        }
    }
}




///////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Choose Pizza Location
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
public static void choosePizzaStoreLocation(string username, StoreRepo stores)
{
    int locationChoice = -1;
    while (locationChoice != 0)
    {
        Console.Clear();
        Console.WriteLine(" __________________________________________________________");
        Console.WriteLine(" | Hello:\t[" + username + "]");
        Console.WriteLine(" |---------------------------------------------------------");
        Console.WriteLine(" | Select a Pizza Parlor Location");
        Console.WriteLine(" |_________________________________________________________");
        int storeCount = 1;

        // read through the list of Pizza parlors available.
        foreach (Store storeLoc in stores.currentStores)
        {
            Console.WriteLine(" |{0}. :  {1}", storeCount, storeLoc.storeName);
            Console.WriteLine(" |        {0}", storeLoc.location);
            Console.WriteLine(" |");
            storeCount++;
        }
        Console.WriteLine(" |0. :  sign out");
        Console.WriteLine(" |_________________________________________________________");
        if (!int.TryParse(Console.ReadLine(), out locationChoice)) // try to read int choice
        {
            Console.WriteLine("Not an int");
            locationChoice = -1;
            continue;
        }

        // choose location and bring up data about that location
        if (locationChoice > 0 && locationChoice <= stores.currentStores.Count)
        {
            // This Object pulls from persisted data from a database on this store's location
            // pertaining to this Cx
            // This will need to be picked up from the database.
            OrderHistory orderHistoryOfCurrentLocation = null;
            // Cx Customers current order selections.  Basically each pizza is a new "order" however
            // It doesn't get it's persistance until checkout where The entire order gets the same order
            // ID to resemble a full order consisting of one or many pizzas.
            OrderHistory LocationOrderHistory = new OrderHistory();
            CurrentOrder CurOrd = new CurrentOrder();

            // Call Main logic for In Store.
            inStoreLogic(username, stores, locationChoice, CurOrd, LocationOrderHistory);
            // In Store Logic

        }
        if (locationChoice == 0)
        {
            Console.WriteLine("returning to the previous page...");
            Thread.Sleep(700);
            break;
        }
    }
}



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Main Logic for initial choices a Cx can make when they login to the store
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="CurOrd"></param>
/// <param name="LocationOrderHistory"></param>
public static void inStoreLogic(string username, StoreRepo stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
{
    int inStoreChoice = -1;
    while (inStoreChoice != 0)
    {
        printStoreHeaderLoggedIn(username, stores, locationChoice);
        Console.WriteLine(" | 1. : Order a Pizza.");
        Console.WriteLine(" | 2. : Preview current order. ");
        Console.WriteLine(" | 3. : Preview your history of orders at this location.");
        Console.WriteLine(" | 0. : Return to Restaurant choice.");
        Console.WriteLine(" |_________________________________________________________");

        if (!int.TryParse(Console.ReadLine(), out inStoreChoice)) // try to read int choice
        {
            Console.WriteLine("Not an option");
            inStoreChoice = -1;
            continue;
        }

        // Pizza Size
        if (inStoreChoice == 1)
        {
            pizzaMakerChoice(username, stores, locationChoice, CurOrd, LocationOrderHistory);
        }

        // This would be the second store
        if (inStoreChoice == 2)
        {
            if (CurOrd.pizzasInOrder.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No pizza's ordered yet!");
                Console.ReadLine();
            }
        }
        // Look at previous order history at current location
        if (inStoreChoice == 3)
        {
            OrderHistory StoresOrdHist = null;
            StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
            printStoreHeaderLoggedIn(username, stores, locationChoice);
            Console.WriteLine(" |_________________________________________________________");
            Console.WriteLine(" | ::Orders::");
            StoresOrdHist.orders = stores.currentStores[locationChoice - 1].userHistoryFromThisStore(username);
            Console.WriteLine(" |_________________________________________________________");
            Console.ReadLine();
        }

        if (inStoreChoice == 0)
        {
            Console.WriteLine("returning to the previous page...");
            Thread.Sleep(700);
            break;
        }
    }
}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// The main logic for Ordering a pizza type
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="CurOrd"></param>
public static void pizzaMakerChoice(string username, StoreRepo stores, int locationChoice, CurrentOrder CurOrd, OrderHistory LocationOrderHistory)
{

    int presetPizzaOptional = -1;
    while (presetPizzaOptional != 0)
    {
        printStoreHeaderLoggedIn(username, stores, locationChoice);
        Console.WriteLine(" |  :: Choose Pizza Type ::");
        Console.WriteLine(" | 1. : Hawaiian");
        Console.WriteLine(" | 2. : Meat Lovers");
        Console.WriteLine(" | 3. : Pepperoni");
        Console.WriteLine(" | 4. : [MAKE YOUR OWN]");
        Console.WriteLine(" | 0. : return to previous page...");
        Console.WriteLine(" |_________________________________________________________");

        if (!int.TryParse(Console.ReadLine(), out presetPizzaOptional)) // try to read int choice
        {
            Console.WriteLine("Not an option");
            presetPizzaOptional = -1;
            continue;
        }
        if (presetPizzaOptional == 4)
        {
            printPizzaSizeChoice(username, stores, locationChoice, "[CUSTOM PIZZA]");
        }

        // Customer chose Hawaiian preset pizza.
        else if (presetPizzaOptional == 1)
        {
            printPizzaSizeChoice(username, stores, locationChoice, "Hawaiian Pizza");
            Pizza HawaiiPizza = new Pizza(); // Comes with sauce and Cheese
            HawaiiPizza.addToppings(Pizza.Toppings.pineapple);
            HawaiiPizza.chooseCrust(Pizza.Crust.deepdish);
            presetPizzaSizeChoice(username, stores, locationChoice, HawaiiPizza, CurOrd);
        }
        // Cx chose Meat Lovers
        else if (presetPizzaOptional == 2)
        {
            printPizzaSizeChoice(username, stores, locationChoice, "Meat Lovers");
            Pizza MeatLovers = new Pizza(); // Comes with sauce and Cheese
            MeatLovers.addToppings(Pizza.Toppings.pepperoni);
            MeatLovers.addToppings(Pizza.Toppings.sausage);
            MeatLovers.chooseCrust(Pizza.Crust.deepdish);
            presetPizzaSizeChoice(username, stores, locationChoice, MeatLovers, CurOrd);
        }
        // Cx chose Pepperoni
        else if (presetPizzaOptional == 3)
        {
            printPizzaSizeChoice(username, stores, locationChoice, "Pepperoni");
            Pizza Pepperoni = new Pizza(); // Comes with sauce and Cheese
            Pepperoni.addToppings(Pizza.Toppings.pepperoni);
            Pepperoni.chooseCrust(Pizza.Crust.deepdish);
            presetPizzaSizeChoice(username, stores, locationChoice, Pepperoni, CurOrd);
        }

        // execute after choosing a pizza, This acts as a persisting layer to persist to a database hopefully.
        if (presetPizzaOptional >= 1 && presetPizzaOptional <= 4)
        {
            checkOutProcedure(username, locationChoice, LocationOrderHistory, CurOrd, stores);
        }

    }
}


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Add a preset Pizza of specified type
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="PresetPizza"></param>
/// <param name="CurOrd"></param>
public static void presetPizzaSizeChoice(string username, StoreRepo stores, int  locationChoice, Pizza PresetPizza, CurrentOrder CurOrd)
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
        if (PizzaConfirmationToOrder(username, stores, locationChoice, PresetPizza))
        {
            // Add The pizza to the order for this restaurant and user
            CurOrd.confirmPizzaOrder(PresetPizza, username, stores.currentStores[locationChoice - 1].storeName);
            // currentOrder.EnterNewCompletedOrder(CurOrd);
            sizeOfPizza = 0;
        }
    }
}



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// checkout procedure
/// </summary>
/// <param name="username"></param>
/// <param name="locationChoice"></param>
/// <param name="LocationOrderHistory"></param>
/// <param name="CurOrd"></param>
/// <param name="stores"></param>
public static void checkOutProcedure(string username, int locationChoice, OrderHistory LocationOrderHistory, CurrentOrder CurOrd, StoreRepo stores)
{
    int checkOutOrAddAnother = -1;
    while (checkOutOrAddAnother != 1 && checkOutOrAddAnother != 2)
    {
        printStoreHeaderLoggedIn(username, stores, locationChoice);
        Console.WriteLine(" | 1. : I'm ready to check out");
        Console.WriteLine(" | 2. : Add another Pizza Already!");
        printCxPrevOrdersAtCurrLoc(username, stores, locationChoice, LocationOrderHistory, CurOrd);
        Console.WriteLine(" |_________________________________________________________");
        if (!int.TryParse(Console.ReadLine(), out checkOutOrAddAnother)) // try to read int choice
        {
            Console.WriteLine("Not an option");
            checkOutOrAddAnother = -1;
            continue;
        }

        // Call method to print Cx Orders
        if (checkOutOrAddAnother == 1)
        {
            LocationOrderHistory.EnterNewCompletedOrder(CurOrd);

        }
        else if (checkOutOrAddAnother == 2)
        {
            Console.Clear();
            Console.WriteLine("Adding Another Pizza");
            Thread.Sleep(600);
        }
    }
}



/////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Call this method to print all Cx Pizza's in their current order
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="currentOrder"></param>
public static void printCxPrevOrdersAtCurrLoc(string username, StoreRepo stores, int locationChoice,
    OrderHistory LocationOrderHistory, CurrentOrder curOrd)
{
    Console.Clear();
    printStoreHeaderLoggedIn(username, stores, locationChoice);

    // write each order Location

    // At each order location write all the pizza sizes, crust and price's in each order
    Console.WriteLine(" | user: <{0}> order totalled: <${1}> |", curOrd.userName, curOrd.currOrderTotal);
    Console.WriteLine(" |----------------------------------------");
    // At each order give brief description of the pizza's ordered
    int pizzaLineCounter = 1;
    foreach (Pizza pOrd in curOrd.pizzasInOrder)
    {

        // give toppings
        Console.Write(" |{0}: {1} {2} pizza with", pizzaLineCounter, pOrd.pizzaSize, pOrd.getCrustChoice());
        List<string> tops = pOrd.getChosenToppings();
        foreach (string pTop in tops)
        {
            Console.Write(" <{0}>", pTop);
        }
        Console.WriteLine();
        Console.WriteLine(" | ---- Pizza Cost ---- <{0}>", pOrd.getPriceOfPizza());
        Console.WriteLine(" |");
        pizzaLineCounter++;
    }
    Console.WriteLine(" |_________________________________________________________\n");

}

///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Print a common reocurring theme
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
public static void printStoreHeaderLoggedIn(string username, StoreRepo stores, int locationChoice)
{
    Console.Clear();
    Console.WriteLine(" __________________________________________________________");
    Console.WriteLine(" | Hello:\t[" + username + "]");
    Console.WriteLine(" |---------------------------------------------------------");
    Console.WriteLine(" | {0} |", stores.currentStores[locationChoice - 1].storeName);
    Console.WriteLine(" |---------------------------------------------------------");
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Print the size options for a pizza
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="PizzaType"></param>
public static void printPizzaSizeChoice(string username, StoreRepo stores, int locationChoice, string PizzaType)
{
    printStoreHeaderLoggedIn(username, stores, locationChoice);
    Console.WriteLine(" |  :: {0} ::  |", PizzaType);
    Console.WriteLine(" |---------------------------------------------------------");
    Console.WriteLine(" | 1. : 12\"");
    Console.WriteLine(" | 2. : 15\"");
    Console.WriteLine(" | 3  : 20\"");
    Console.WriteLine(" | 0  : return to previous page...");
    Console.WriteLine(" |_________________________________________________________");
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Allow the user an opportunity to back out of a pizza, not the entire order.
/// </summary>
/// <param name="username"></param>
/// <param name="stores"></param>
/// <param name="locationChoice"></param>
/// <param name="HawaiiPizza"></param>
/// <returns></returns>
public static bool PizzaConfirmationToOrder(string username, StoreRepo stores, int locationChoice, Pizza PizzaChoice)
{
    Console.WriteLine("CHECK");
    int confirm = -1;
    while (!(confirm >=1 && confirm <=2)) {
        printStoreHeaderLoggedIn(username, stores, locationChoice);
        Console.WriteLine(" | %%% Price of pizza adding to order: ${0} %%%|", PizzaChoice.getPriceOfPizza());
        Console.WriteLine(" |------------------------------");
        Console.WriteLine(" |1. : Confirm Pizza order");
        Console.WriteLine(" |2. : return to previous menu...");
        Console.WriteLine(" |_________________________________________________________");
        if (!int.TryParse(Console.ReadLine(), out confirm))
        {
            Console.WriteLine("Not an option");
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
*/
