using System;
using System.Collections.Generic;
using PizzaBox.Domain;


namespace PizzaBox.Storing
{
    public class StoreRepo : PizzaBox.Domain.Store
    {
        // Handles multiple store Locations
        public List<Store> currentStores;

        public StoreRepo()
        {
            currentStores = new List<Store>();
            readInStoreInfo();
        }

        /// <summary>
        /// Initialize two locations
        /// </summary>
        private void readInStoreInfo()
        {
            Store store = new Store();
            store.storeName = "Pizza of the Sea";
            store.location = "P. Shermin 42 Wallabe Way, Sydney";
            currentStores.Add(store);


            store = new Store();
            store.storeName = "Crazy Good Pizza";
            store.location = "3500 W 6th St Unit# 110, Los Angeles, CA 90020";
            currentStores.Add(store);
        }

        /// <summary>
        /// Allows for the addition of new store locations
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="storeLocation"></param>
        public void addNewStore(string storeName, string storeLocation)
        {
            Store store = new Store();
            store.storeName = storeName;
            store.location = storeLocation;
            currentStores.Add(store);

        }



    }
}
