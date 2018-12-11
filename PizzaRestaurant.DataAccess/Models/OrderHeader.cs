using System;
using System.Collections.Generic;

namespace PizzaRestaurant.DataAccess
{
    public partial class OrderHeader
    {
        public OrderHeader()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int OrderAddressId { get; set; }
        public int TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }

        public virtual Address OrderAddress { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
