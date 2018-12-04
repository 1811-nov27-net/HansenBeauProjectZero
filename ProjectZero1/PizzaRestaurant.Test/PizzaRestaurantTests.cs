using System;
using Xunit;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.Test
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
