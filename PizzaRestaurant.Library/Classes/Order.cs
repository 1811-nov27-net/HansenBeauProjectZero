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

        public int orderID { get; set; }

        public int userID { get; set; }

        public int orderAddressID { get; set; }

        public List<Product> orderProducts { get; set; } = new List<Product>();

        public int totalCost { get; set; }

        public DateTime orderDate { get; set; }

        public int storeId { get; set; }

        public List<OrderDetail> orderDetail { get; set; } = new List<OrderDetail>();

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
                else
                {
                    bool insert = true;
                    
                    foreach (var item in orderDetail)
                    {
                        if (item.ProductId == product.productID)
                        {
                            insert = false;
                            item.QtyOrdered++;
                        }
                    }

                    if(insert == true)
                    {
                        orderDetail.Add(new OrderDetail() { ProductId = product.productID, QtyOrdered = 1 });
                    }
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
