using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int QtyOrdered { get; set; }

        
    }
}
