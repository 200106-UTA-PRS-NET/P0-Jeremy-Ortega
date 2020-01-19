using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaBox.Storing.Repositories
{
    class LocationOrderHistory
    {

        StoreRepo stores;

        public LocationOrderHistory()
        {

        }


        public void ChooseVewOrdersOrStorePortal(string username)
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
                if (signedInChoice == 3)
                {

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
                */
                /*
                 * This choice signifies selecting the pizza parlor you wish to engage with 
                 */
                if (signedInChoice == 1)
                {
                    choosePizzaStoreLocation(username, stores);
                }
            }
        }
    }
}
