using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
         Product GetProductByID(int productId);
    }
}
