using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.TestModels
{
    public class Order1
    {
        public int OrderId { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
        public decimal Price { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
