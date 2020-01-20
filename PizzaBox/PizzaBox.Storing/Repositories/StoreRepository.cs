using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using System.Linq;
using PizzaBox.Storing.Mappings;

namespace PizzaBox.Storing.Repositories
{
    public class StoreRepository : IRepositoryStore<Store1>
    {
        //// Handles multiple store Locations
        //public List<Store> currentStores;

        //public StoreRepository()
        //{
        //    currentStores = new List<Store>();
        //    readInStoreInfo();
        //}

        ///// <summary>
        ///// Initialize two locations
        ///// </summary>
        //private void readInStoreInfo()
        //{
        //    Store store = new Store();
        //    store.storeName = "Pizza of the Sea";
        //    store.location = "P. Shermin 42 Wallabe Way, Sydney";
        //    currentStores.Add(store);


        //    store = new Store();
        //    store.storeName = "Crazy Good Pizza";
        //    store.location = "3500 W 6th St Unit# 110, Los Angeles, CA 90020";
        //    currentStores.Add(store);
        //}

        ///// <summary>
        ///// Allows for the addition of new store locations
        ///// </summary>
        ///// <param name="storeName"></param>
        ///// <param name="storeLocation"></param>
        //public void addNewStore(string storeName, string storeLocation)
        //{
        //    Store store = new Store();
        //    store.storeName = storeName;
        //    store.location = storeLocation;
        //    currentStores.Add(store);

        //}

        Project0Context PC;
        public StoreRepository()
        {
            PC = new Project0Context();
        }
        public StoreRepository(Project0Context PC)
        {
            // Directly taken from the aformentioned model by Pushpinder Kaur.
            this.PC = PC ?? throw new ArgumentNullException(nameof(PC));
        }

        public void CreateStore(Store1 Store)
        {
            //if (PC.CxOrder.Any(c => c.OrderId == order.) || order.Phone == null)
            //{
            //    Console.WriteLine($"This order with username {order.Username} already exists and cannot be added");
            //    return;
            //}
            //else
            PC.Store.Add(MapStore.Map(Store));// this will generate insertMapper.Map(order)
            PC.SaveChanges();// this will execute the above generate insert query
        }

        public void DeleteStore(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store1> ReadInStore()
        {
            var getPizza = from P in PC.Store
                           select MapStore.Map(P);

            return getPizza;
        }

        public void UpdateStore(Store1 Order)
        {
            throw new NotImplementedException();
        }
    }
}
