using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Products
    {
        public Products()
        {
            OrderDetail = new HashSet<OrderDetail>();
            StoreInventory = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<StoreInventory> StoreInventory { get; set; }
    }
}
