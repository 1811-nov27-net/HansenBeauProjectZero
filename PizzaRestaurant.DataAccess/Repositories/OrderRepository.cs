using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

        public void DisplayOrderDetailsByOrderID(int orderID)
        {
            Order orderToDisplay = GetOrderByOrderId(orderID);
            Console.WriteLine("Order ID: " + orderToDisplay.orderID + " ");
            Console.WriteLine("User ID: " + orderToDisplay.userID + " ");
            Console.WriteLine("Order Address ID: " + orderToDisplay.orderAddressID + " ");
            Console.WriteLine("Total Cost: $" + orderToDisplay.totalCost + " ");
            Console.WriteLine("Order Date ID: " + orderToDisplay.orderDate + " ");
            Console.WriteLine("Store ID: " + orderToDisplay.storeId + " ");
            List<Product> listOfProducts = GetProductsOfOrderByID(orderID).ToList();
            Console.WriteLine("Products in the order");
            foreach (var item in listOfProducts)
            {
                Console.WriteLine("here");
                Console.WriteLine("Product: " + item.productName + "Unit Price: " + item.unitPrice);
            }
        }

        public IEnumerable<Order> GetOrders()
        {
           return Mapper.Map(_db.OrderHeader);
        }

        public void InsertOrder(Order order)
        {
            _db.OrderHeader.Include(o => o.OrderDetail);
            _db.Add(Mapper.Map(order));
        }

        public void Save()
        {
            _db.SaveChanges();
            Console.WriteLine("Order saved to database");

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
            return orderCollection.OrderBy(o => o.orderDate).Where(o => o.userID == user);
        }

        public IEnumerable<Order> DisplayOrderHistoryStore(int store)
        {
            IEnumerable<Order> orderCollection = Mapper.Map(_db.OrderHeader);
            return orderCollection.Where(o => o.storeId == store);
        }

        public IEnumerable<Order> DisplayOrderHistory(string sortOrder)
        {
            if (sortOrder.ToLower() == "e")
            {
                IEnumerable<Order> orderHistory = Mapper.Map(_db.OrderHeader);
                return orderHistory.OrderBy(o => o.orderDate);
            }
            else if (sortOrder.ToLower() == "l")
            {
                IEnumerable<Order> orderHistory = Mapper.Map(_db.OrderHeader);
                return orderHistory.OrderByDescending(o => o.orderDate);
            }
            else if (sortOrder.ToLower() == "c")
            {
                IEnumerable<Order> orderHistory = Mapper.Map(_db.OrderHeader);
                return orderHistory.OrderBy(o => o.totalCost);
            }
            else if (sortOrder.ToLower() == "x")
            {
                IEnumerable<Order> orderHistory = Mapper.Map(_db.OrderHeader);
                return orderHistory.OrderByDescending(o => o.totalCost);
            }
            else
            {
                // this is the same code a sfor the case "earliest"
                // I am using it as a default, and I will check for valid inputs in the 
                // ConsoleApp
                IEnumerable<Order> orderHistory = Mapper.Map(_db.OrderHeader);
                return orderHistory.OrderBy(o => o.orderDate);
            }
        }

        public IEnumerable<Product> GetProductsOfOrderByID(int orderID)
        {
            List<DataAccess.OrderDetail> orderDetailInter = _db.OrderDetail.Where(o => o.OrderId == orderID).ToList();
            List<Product> orderProducts = new List<Product>();
            ProductsRepository productRepo = new ProductsRepository(_db);
            foreach (var item in orderDetailInter)
            {
                Product product = productRepo.GetProductByID(item.ProductId);
                orderProducts.Add(product);
            }
            return orderProducts;
        }

        public Order GetOrderByOrderId(int orderID)
        {
            return Mapper.Map(_db.OrderHeader.Where(o => o.OrderId == orderID).First());
        }


        public int getLastId()
        {
            Order o = Mapper.Map(_db.OrderHeader.OrderByDescending(or => or.OrderId).First());
            return o.orderID;
        }

        
    }
}
