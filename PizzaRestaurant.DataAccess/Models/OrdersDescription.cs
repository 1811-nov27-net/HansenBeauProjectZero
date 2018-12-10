using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class OrdersDescription
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int QtyOrdered { get; set; }

        public virtual Menu Item { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
