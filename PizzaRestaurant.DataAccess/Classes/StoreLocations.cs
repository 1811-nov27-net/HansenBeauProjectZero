using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class StoreLocations
    {
        public StoreLocations()
        {
            Orders = new HashSet<Orders>();
        }

        public int StoreLocId { get; set; }
        public string StoreName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
