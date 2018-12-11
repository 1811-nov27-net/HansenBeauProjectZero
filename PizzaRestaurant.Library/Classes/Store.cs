using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Store
    {
        private int _storeID;
        public int storeID { get; set; }

        private string _sAddressLine1;
        public string sAddressLine1 { get; set; }

        private string _sAddressLine2;
        public string sAddressLine2 { get; set; }

        private string _sCity;
        public string sCity { get; set; }

        private string _sState;
        public string sState { get; set; }

        private int _sZipCode;
        public int sZipCode { get; set; }

        public List<Order> listOrders { get; set; } = new List<Order>();
        public List<StoreInventory> listStoreInventory { get; set; } = new List<StoreInventory>();
    }
}
