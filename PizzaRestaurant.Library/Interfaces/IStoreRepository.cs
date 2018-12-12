using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetStores();
        Store GetStoreByID(int storeID);
    }
}
