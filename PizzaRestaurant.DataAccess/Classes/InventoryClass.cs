using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class InventoryClass
    {
        public InventoryClass()
        {
            InventoryType = new HashSet<InventoryType>();
        }

        public int ItemClassId { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<InventoryType> InventoryType { get; set; }
    }
}
