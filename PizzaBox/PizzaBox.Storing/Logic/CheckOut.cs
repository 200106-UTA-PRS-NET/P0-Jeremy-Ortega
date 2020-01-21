using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Storing.Logic
{
    public class CheckOut
    {
        ZZ_PrintLoggedInHeader PH;
        CxOrdersAtLocation COL;
        public CheckOut()
        {
            PH = new ZZ_PrintLoggedInHeader();
            COL = new CxOrdersAtLocation();

        }
        /// <summary>
        /// checkout procedure
        /// </summary>
        /// <param name="username"></param>
        /// <param name="locationChoice"></param>
        /// <param name="LocationOrderHistory"></param>
        /// <param name="CurOrd"></param>
        /// <param name="stores"></param>
        public void checkOutProcedure(string username, int locationChoice, OrderHistory LocationOrderHistory, CurrentOrder CurOrd, StoreRepository stores)
        {
            int checkOutOrAddAnother = -1;
            while (checkOutOrAddAnother != 1 && checkOutOrAddAnother != 2)
            {
                // PH.printStoreHeaderLoggedIn(username, stores);
                Console.WriteLine(" | 1. : I'm ready to check out");
                Console.WriteLine(" | 2. : Add another Pizza Already!");
                //COL.printCxPrevOrdersAtCurrLoc(username, stores, locationChoice, LocationOrderHistory, CurOrd);
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
    }
}
