using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Xunit;
using PizzaRestaurant.Library;

namespace ProjectZero1
{
    public class PizzaRestaurantTests
    {
        [Fact]
        public void UserFirstNameIsEmptyStringForDefaultUser()
        {
            // arrange
            User sut = new User();

            // act
            string result = sut.fName;

            // assert
            Assert.Equal("", result);
        }
        
        [Theory]
        [InlineData("Beau")]
        public void UserFirstNameIsCorrectlyConstructedForOneArgumentPassed(string value)
        {
            // arrange
            User sut = new User(value);

            // act
            string result = sut.fName;

            // assert
            Assert.Equal(value, result);
        }
    }
}
