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
        IEnumerable<Order> GetOrders();
        Order DisplayOrderDetails(Order order);
        IEnumerable<Order> DisplayOrderHistoryAddress(int address);
        IEnumerable<Order> DisplayOrderHistoryUser(int user);
        IEnumerable<Order> DisplayOrderHistory(string sortOrder);
        void Save();

    }
}
