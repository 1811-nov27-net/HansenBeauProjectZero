using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Address
    {
        public Address()
        {
            OrderHeader = new HashSet<OrderHeader>();
        }

        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderHeader> OrderHeader { get; set; }
    }
}
