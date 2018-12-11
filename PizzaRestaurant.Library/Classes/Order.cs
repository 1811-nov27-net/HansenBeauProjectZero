using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class Order
    {
        public Order()
        {
            
        }

        private int _orderID;
        public int orderID { get; set; }

        private int _userID;
        public int userID { get; set; }

        private int _orderAddressId;
        public int orderAddressID { get; set; }

        public List<Product> orderProducts { get; set; } = new List<Product>();

        private int _totalCost;
        public int totalCost { get; set; }

        private DateTime _orderDate;
        public DateTime orderDate { get; set; }

        private int _storeId;
        public int storeId { get; set; }

        public void AddToOrder(Product product)
        {
            if (orderProducts.Count < 12)
            {
                this.orderProducts.Add(product);
                this.totalCost += product.unitPrice;
                if (totalCost > 500)
                {
                    Console.WriteLine("You cannot exceed $500 for an order. Product not added.");
                    this.orderProducts.Remove(product);
                    this.totalCost -= product.unitPrice;
                }
                Console.WriteLine("Product added to order.");
            }
            else
            {
                Console.WriteLine("You already have the maximum number of pizzas in your order (12). Product not added.");
            }
        }
    }
}
