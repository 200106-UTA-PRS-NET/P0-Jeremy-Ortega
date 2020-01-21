using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Mappings
{
    class MapOrder
    {
        public static Order1 Map(Domain.Models.CxOrder Cx)
        {
            return new Order1()
            {
                OrderId = Cx.OrderId,
                CustId = Cx.CustId,
                StoreId = Cx.StoreId,
                Price = Cx.Price,
                OrderDate = Cx.OrderDate
            };
        }
        public static Domain.Models.CxOrder Map(Order1 Cx)
        {
            return new Domain.Models.CxOrder()
            {
                OrderId = Cx.OrderId,
                CustId = Cx.CustId,
                StoreId = Cx.StoreId,
                Price = Cx.Price,
                OrderDate = Cx.OrderDate
            };
        }
    }
}
