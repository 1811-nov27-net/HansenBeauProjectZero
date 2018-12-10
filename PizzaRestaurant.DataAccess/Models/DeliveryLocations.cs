using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class DeliveryLocations
    {
        public DeliveryLocations()
        {
            Orders = new HashSet<Orders>();
        }

        public int DeliveryLocId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
