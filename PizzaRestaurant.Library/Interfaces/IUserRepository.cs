using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IUserRepository
    {
        /// <summary>
        /// View all users
        /// </summary>
        /// <returns>The collection of Users</returns>
        //List<User> GetUsers();

        /// <summary>
        /// Add a user to the PizzaOrders.Users table
        /// </summary>
        void AddUser(User user);

        /// <summary>
        /// Remove User from PizzaOrders.Users table
        /// </summary>
        void DeleteUser(User user);

        /// <summary>
        /// 
        /// </summary>
        void UpdateUser();


        /// <summary>
        /// Save any changes
        /// </summary>
        void Save();

        
        
    }
}
