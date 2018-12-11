using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.DataAccess
{
    class Mapper
    {
        public static Library.User Map(Users user) => new Library.User
        {
            userID = user.UserId,
            firstName = user.FirstName,
            lastName = user.LastName,
            defaultAddressID = user.DefaultAddressId
        };

        public static DataAccess.Users Map(Library.User user) => new DataAccess.Users
        {
            UserId = user.userID,
            FirstName = user.firstName,
            LastName = user.lastName,
            DefaultAddressId = user.defaultAddressID
        };

        public static DataAccess.OrderHeader Map(Library.Order order) => new DataAccess.OrderHeader
        {
            OrderId = order.orderID,
            UserId = order.userID,
            OrderAddressId = order.orderAddressID,
            TotalCost = order.totalCost,
            OrderDate = order.orderDate,
            StoreId = order.storeId
        };

        public static Library.Order Map(DataAccess.OrderHeader order) => new Library.Order
        {
            orderID = order.OrderId,
            userID = order.UserId,
            orderAddressID = order.OrderAddressId,
            totalCost = order.TotalCost,
            orderDate = order.OrderDate,
            storeId = order.StoreId
        };

        public static Library.Product Map(DataAccess.Products product) => new Library.Product
        {
            productID = product.ProductId,
            productName = product.ProductName,
            unitPrice = product.UnitPrice
        };

        public static IEnumerable<User> Map(IEnumerable<Users> user) => user.Select(Map);

        public static IEnumerable<Order> Map(IEnumerable<OrderHeader> order) => order.Select(Map);

        public static IEnumerable<Product> Map(IEnumerable<Products> product) => product.Select(Map);
    }
}
