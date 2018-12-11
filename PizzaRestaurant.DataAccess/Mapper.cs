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
    }
}
