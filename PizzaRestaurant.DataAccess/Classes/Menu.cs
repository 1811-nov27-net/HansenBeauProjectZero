using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Menu
    {
        public Menu()
        {
            OrdersDescription = new HashSet<OrdersDescription>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCost { get; set; }
        public string ItemSize { get; set; }
        public int ItemTypeId { get; set; }

        public virtual InventoryType ItemType { get; set; }
        public virtual ICollection<OrdersDescription> OrdersDescription { get; set; }
    }
}
