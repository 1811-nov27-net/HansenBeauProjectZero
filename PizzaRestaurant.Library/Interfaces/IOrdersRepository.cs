using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IOrdersRepository
    {
        void InsertOrder(Order order);
        void DeleteOrder(int orderID);
        void UpdateOrder(Order order);
        IEnumerable<Product> GetProductsOfOrderByID(int OrderID);
        IEnumerable<Order> GetOrders();
        Order GetOrderByOrderId(int orderID);
        void DisplayOrderDetailsByOrderID(int orderID);
        IEnumerable<Order> DisplayOrderHistoryAddress(int address);
        IEnumerable<Order> DisplayOrderHistoryUser(int user);
        IEnumerable<Order> DisplayOrderHistory(string sortOrder);
        int getLastId();
        void Save();

    }
}
