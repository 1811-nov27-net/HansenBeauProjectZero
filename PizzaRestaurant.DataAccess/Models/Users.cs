using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaRestaurant.DataAccess
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastOrderTime { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
