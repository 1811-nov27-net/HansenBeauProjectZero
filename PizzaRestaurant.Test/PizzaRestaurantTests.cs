using System;
using Xunit;
using PizzaRestaurant.Library;
using PizzaRestaurant.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace PizzaRestaurant.Test
{
    public class PizzaRestaurantTests
    {
        [Theory]
        [InlineData(1, 18)]
        [InlineData(2, 15)]
        [InlineData(3, 12)]
        [InlineData(4, 18)]
        [InlineData(5, 15)]
        [InlineData(6, 12)]
        [InlineData(7, 18)]
        [InlineData(8, 15)]
        [InlineData(9, 12)]
        public void ProductPriceIsAddedCorrectly(int productID, int expectedCost)
        {
            // arrange
            var optionsBuilder = new DbContextOptionsBuilder<PizzaOrdersContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;
            var dbContext = new PizzaOrdersContext(options);
            ProductsRepository productsRepository = new ProductsRepository(dbContext);

            Product sutProduct = productsRepository.GetProductByID(productID);

            Order sutOrder = new Order();

            // act
            sutOrder.AddToOrder(sutProduct);

            // assert
            Assert.Equal(expectedCost, sutOrder.totalCost);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(1, 5)]
        [InlineData(6, 5)]
        [InlineData(6, 6)]
        [InlineData(6, 7)]
        [InlineData(6, 8)]
        [InlineData(6, 9)]

        public void WillNotAddAThirteenthProductToOrder(int productIDToStore, int productIDToTryToAdd)
        {
            // arrange
            var optionsBuilder = new DbContextOptionsBuilder<PizzaOrdersContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;
            var dbContext = new PizzaOrdersContext(options);
            ProductsRepository productsRepository = new ProductsRepository(dbContext);

            Product dummyProduct = productsRepository.GetProductByID(productIDToStore);

            Order sutOrder = new Order();

            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);
            sutOrder.AddToOrder(dummyProduct);

            Product sutProduct = productsRepository.GetProductByID(productIDToTryToAdd);
            // act
            sutOrder.AddToOrder(sutProduct);

            // assert
            Assert.False(sutOrder.orderProducts.Count != 12);
        }

        [Theory]
        [InlineData(1, 490)]
        [InlineData(2, 499)]
        [InlineData(3, 500)]
        [InlineData(4, 483)]
        public void OrderPriceWillNotExceed500(int productID, int startingTotalValue)
        {
            // arrange
            var optionsBuilder = new DbContextOptionsBuilder<PizzaOrdersContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;
            var dbContext = new PizzaOrdersContext(options);
            ProductsRepository productsRepository = new ProductsRepository(dbContext);

            Product sutProduct = productsRepository.GetProductByID(productID);

            Order sutOrder = new Order();
            sutOrder.totalCost = startingTotalValue;

            // act
            sutOrder.AddToOrder(sutProduct);

            // assert
            Assert.False(sutOrder.totalCost > 500);
        }

        [Theory]
        [InlineData(501)]
        [InlineData(500.5)]
        [InlineData(5 * 100.1)]
        [InlineData(600)]
        public void OrderPriceCannotExceed500ViaHardSetting(int hardSetTotalCost)
        {
            // arrange
            Order sutOrder = new Order();

            // act
            sutOrder.totalCost = hardSetTotalCost;

            // assert
            Assert.False(sutOrder.totalCost > 500);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.01)]
        [InlineData(-(Math.PI))]
        [InlineData(-1000)]

        public void OrderPriceCannotBeANegativeValue(int hardSetTotalCost)
        {
            // arrange
            Order sutOrder = new Order();

            // act
            sutOrder.totalCost = hardSetTotalCost;

            // assert
            Assert.False(sutOrder.totalCost < 0);
        }

        //[Theory]
        //[InlineData("Johnny")]
        //[InlineData("johnny")]
        //[InlineData("7 eleven")]
        //[InlineData(null)]
        //[InlineData("")]
        //public void UserFirstNameStoersCorrectly(string sampleName)
        //{
        //    // arrange
        //    User sut = new User(sampleName);
        //    // act
        //    // act is done behind-the-scenes in the constructor
        //    // assert
        //    Assert.Equal(sampleName, sut.firstName);
        //}
    }
}
