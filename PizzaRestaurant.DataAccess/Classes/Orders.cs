using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal SubTotal { get; set; }
        public decimal NetTotal { get; set; }
        public int DeliveryAddressId { get; set; }

        public virtual DeliveryLocations DeliveryAddress { get; set; }
        public virtual OrdersDescription Order { get; set; }
        public virtual StoreLocations Store { get; set; }
        public virtual Users User { get; set; }
    }
}
