using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class StoreInventory
    {
        public int StoreInventoryId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int QtyRemaining { get; set; }

        public virtual Products Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
