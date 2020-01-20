using PizzaBox.Storing.TestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Mappings
{
    public class MapStore
    {
        public static Store1 Map(Domain.Models.Store S)
        {
            return new Store1()
            {
                Id = S.Id,
                StoreLocation = S.StoreLocation,
                StoreName = S.StoreName
            };
        }
        public static Domain.Models.Store Map(Store1 S)
        {
            return new Domain.Models.Store()
            {
                Id=S.Id,
                StoreLocation=S.StoreLocation,
                StoreName=S.StoreName
            };
        }
    }
}
