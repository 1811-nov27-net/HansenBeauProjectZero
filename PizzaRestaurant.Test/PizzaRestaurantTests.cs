//using System;
//using Xunit;
//using PizzaRestaurant.Library;

//namespace PizzaRestaurant.Test
//{
//    public class PizzaRestaurantTests
//    {
//        [Fact]
//        public void UserFirstNameIsEmptyStringForDefaultUser()
//        {
//            // arrange
//            User sut = new User();

//            // act
//            string result = sut.fName;

//            // assert
//            Assert.Equal("", result);
//        }

//        [Theory]
//        [InlineData("Beau")]
//        [InlineData("")]
//        [InlineData(null)]
//        [InlineData("123")]
//        [InlineData("John Paul")]
//        public void UserFirstNameIsCorrectlyConstructedForOneArgumentPassed(string value)
//        {
//            // arrange
//            User sut = new User(value);

//            // act
//            string result = sut.fName;
            
//            // assert
//            if (value != null)
//            {
//                Assert.Equal(value, result);
//            }
//            else
//            {
//                Assert.Equal("", result);
//            }
            
//        }

//        [Theory]
//        [InlineData( "Beau", "Hansen" , "Hansen" )]
//        [InlineData("", "Hansen", "Hansen")]
//        [InlineData(null, "Hansen", "Hansen")]
//        [InlineData("Beau", "", "")]
//        [InlineData(null, null, "")]
//        public void UserLastNameConstructedCorrectlyWhenPassingTwoParameters(string value1, string value2, string expected)
//        {
//            // arrange
//            User sut = new User(value1, value2);

//            // act
//            string result = sut.lName;

//            // assert
//            Assert.Equal(expected, result);
//        }

//        [Fact] //?
//        public void DateTimeSetsToCurrent()
//        {

//        }
//    }
//}
