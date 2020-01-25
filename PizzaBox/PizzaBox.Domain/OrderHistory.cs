using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{

    public class OrderHistory
    {

        //public List<CurrentOrder> CxOrderHistory { get; set; }

        public List<CurrentOrder> orders;

        public OrderHistory()
        {
            orders = new List<CurrentOrder>();
        }

        public void EnterNewCompletedOrder(CurrentOrder order)
        {
            orders.Add(order);
        }
    }


}
