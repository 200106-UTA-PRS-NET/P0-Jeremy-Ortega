using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.OldModels
{
    public partial class CxOrder
    {
        public CxOrder()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
