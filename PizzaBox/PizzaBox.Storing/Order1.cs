using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing
{
    public class Order1
    {
        public int OrderId { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
