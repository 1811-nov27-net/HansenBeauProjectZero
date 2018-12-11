using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.DataAccess
{
    public class OrderRepository : IOrdersRepository, IDisposable
    {

        private readonly PizzaOrdersContext _db;

        public OrderRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void DeleteOrder(int orderID)
        {
            _db.Remove(_db.OrderDetail.Find(orderID));
        }

        public Order DisplayOrderDetails(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Order order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> DisplayOrderHistoryAddress(int address)
        {
            IEnumerable<Order> orderCollection = Mapper.Map(_db.OrderHeader);
            return orderCollection.Where(o => o.orderAddressID == address);
        }

        public IEnumerable<Order> DisplayOrderHistoryUser(int user)
        {
            IEnumerable<Order> orderCollection = Mapper.Map(_db.OrderHeader);
            return orderCollection.OrderBy(o => o.orderDate);
        }

        public IEnumerable<Order> DisplayOrderHistory(string sortOrder)
        {
            throw new NotImplementedException();
        }
    }
}
