using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Store
    {
        public int storeID { get; set; }

        public string sAddressLine1 { get; set; }

        public string sAddressLine2 { get; set; }

        public string sCity { get; set; }

        public string sState { get; set; }

        public int sZipCode { get; set; }

        public List<Order> listOrders { get; set; } = new List<Order>();
        public List<StoreInventory> listStoreInventory { get; set; } = new List<StoreInventory>();
    }
}
