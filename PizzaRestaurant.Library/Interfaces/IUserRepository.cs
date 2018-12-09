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
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Add a user to the PizzaOrders.Users table
        /// </summary>
        void AddUser();

        /// <summary>
        /// Remove User from PizzaOrders.Users table
        /// </summary>
        void DeleteUser();

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
