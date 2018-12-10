using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class InventoryType
    {
        public InventoryType()
        {
            Menu = new HashSet<Menu>();
        }

        public int ItemTypeId { get; set; }
        public string TypeName { get; set; }
        public int ItemClassId { get; set; }

        public virtual InventoryClass ItemClass { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
