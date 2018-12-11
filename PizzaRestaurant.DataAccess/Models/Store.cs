using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Store
    {
        public Store()
        {
            OrderHeader = new HashSet<OrderHeader>();
            StoreInventory = new HashSet<StoreInventory>();
        }

        public int StoreId { get; set; }
        public string SaddressLine1 { get; set; }
        public string SaddressLine2 { get; set; }
        public string Scity { get; set; }
        public string Sstate { get; set; }
        public int Szipcode { get; set; }

        public virtual ICollection<OrderHeader> OrderHeader { get; set; }
        public virtual ICollection<StoreInventory> StoreInventory { get; set; }
    }
}
