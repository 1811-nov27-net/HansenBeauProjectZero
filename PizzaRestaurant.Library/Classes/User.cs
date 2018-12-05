using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public class User
    {
        /// <summary>
        /// HashSet to hold collection of Users.  HashSet is collection of choice 
        /// to avoid storing multiple copies of the same user, and because 
        /// indexing is not important.  Use of this HashSet is to aid in searching
        /// for a user (LINQ, probably), and searching
        /// </summary>
        static Dictionary<User, List<Order>> UserDatabase = new Dictionary<User, List<Order>>()
        {

        };
        /// <summary>
        /// constructors are designed initialize fName, lName, and location. 
        /// multiple constructors are utilized to give choice to the client
        /// to pass through the fields that he/she wants
        /// </summary>
        //public User()
        //{
        //    _deliveryName = "";
        //    _location1 = "";
        //    _location2 = "";
        //    _location3 = "";

        //}

        //public User(string inputName, string inputLoc1, string inputLoc2, string inputLoc3)
        //{
        //    _deliveryName = inputName;
        //    _location1 = inputLoc1;
        //    _location2 = inputLoc2;
        //    _location3 = inputLoc3;
        //}


        /// <summary>
        /// the properties for "First Name", "Last Name", and "Location" 
        /// are built as read-write with back calling
        /// </summary>
        private string _deliveryName;
        public string deliveryName
        {
            get => _deliveryName;
            set
            {
                if (value != null)
                {
                    _deliveryName = value;
                }
                else
                {
                    _deliveryName = "";
                };
            }
        }

        
    }
}
