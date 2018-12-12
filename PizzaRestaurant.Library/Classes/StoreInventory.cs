using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class StoreInventory
    {
        public int StoreInventoryId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int QtyRemaining { get; set; }
        public ICollection<OrderDetail> orderDetail { get; set; }
    }
}
