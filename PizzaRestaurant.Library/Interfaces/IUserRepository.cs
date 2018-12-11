using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUsersByName(string fName, string lName);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userID);
        void Save();
    }
}