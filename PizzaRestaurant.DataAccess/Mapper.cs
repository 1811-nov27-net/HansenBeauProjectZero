using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.DataAccess
{
    public class Mapper
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
            StoreId = order.storeId,
            OrderDetail = Map(order.orderDetail).ToList()
        };

        public static DataAccess.OrderDetail Map(Library.OrderDetail orderDetail) => new DataAccess.OrderDetail
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            QtyOrdered = orderDetail.QtyOrdered,

            //Order=orderDetail.Order,
            //Products=orderDetail.Product,
        };

        public static Library.OrderDetail Map(DataAccess.OrderDetail orderDetail) => new Library.OrderDetail
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            QtyOrdered = orderDetail.QtyOrdered

            //Order=orderDetail.Order,
            //Products=orderDetail.Product,
        };

        public static Library.Order Map(DataAccess.OrderHeader order) => new Library.Order
        {
            orderID = order.OrderId,
            userID = order.UserId,
            orderAddressID = order.OrderAddressId,
            totalCost = order.TotalCost,
            orderDate = order.OrderDate,
            storeId = order.StoreId,
            orderDetail = Map(order.OrderDetail).ToList()
            //orderProducts = order.OrderProducts,
            // Currently, this tries to convert a DataAccess.Products to a List<Product>. Need to Fix
            // orderProducts.Add(Map(MapOrderDetailtoProducts(MapOrderHeadertoOrderDetail(order))));
        };

        public static Library.Product Map(DataAccess.Products product) => new Library.Product
        {
            productID = product.ProductId,
            productName = product.ProductName,
            unitPrice = product.UnitPrice
        };

        public static Library.Address Map(DataAccess.Address address) => new Library.Address
        {
            addressID = address.AddressId,
            userID = address.UserId,
            addressLine1 = address.AddressLine1,
            addressLine2 = address.AddressLine2,
            city = address.City,
            state = address.State,
            zipCode = address.Zipcode
        };




        public static DataAccess.OrderDetail MapOrderHeadertoOrderDetail(DataAccess.OrderHeader order) => new DataAccess.OrderDetail
        {
            OrderId = order.OrderId
        };

        public static DataAccess.Products MapOrderDetailtoProducts(DataAccess.OrderDetail order) => new DataAccess.Products
        {
            ProductId = order.ProductId
        };

        public static IEnumerable<User> Map(IEnumerable<Users> user) => user.Select(Map);

        public static IEnumerable<DataAccess.OrderDetail> Map(ICollection<Library.OrderDetail> orderDetail) => orderDetail.Select(Map);

        public static IEnumerable<Library.OrderDetail> Map(ICollection<DataAccess.OrderDetail> orderDetail) => orderDetail.Select(Map);

        //public static IEnumerable<Library.OrderDetail> Map(ICollection<DataAccess.OrderDetail> orderDetail) => orderDetail.Select(Map);

        public static IEnumerable<Order> Map(IEnumerable<OrderHeader> order) => order.Select(Map);

        public static IEnumerable<Product> Map(IEnumerable<Products> product) => product.Select(Map);
    }
}

