using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultAddressId { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
