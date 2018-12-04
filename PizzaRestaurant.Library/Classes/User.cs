using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;
using Xunit;

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
        //static Dictionary<User, List<Order>> UserDatabase = new Dictionary<User, List<Order>>()
        //{

        //}
        /// <summary>
        /// constructors are designed initialize fName, lName, and location. 
        /// multiple constructors are utilized to give choice to the client
        /// to pass through the fields that he/she wants
        /// </summary>
        public User()
        {
            _fName = "";
            _lName = "";
            _location = "";
        }

        public User(string inputFName)
        {
            _fName = "inputFName";
            _lName = "";
            _location = "";
        }

        public User(string inputFName, string inputLName)
        {
            _fName = "inputFName";
            _lName = "inputLName";
            _location = "";
        }

        public User(string inputFName, string inputLName, string inputLocation)
        {
            _fName = "inputFName";
            _lName = "inputLName";
            _location = "inputLocation";
        }

        /// <summary>
        /// the properties for "First Name", "Last Name", and "Location" 
        /// are built as read-write with back calling
        /// </summary>
        private string _fName;
        public string fName
        {
            get => _fName;
            set
            {
                if (value != "" && value != null)
                {
                    _fName = value;
                };
            }
        }

        private string _lName;
        public string lName
        {
            get => _lName;
            set
            {
                if (value != "" && value != null)
                {
                    _lName = value;
                };
            }
        }

        private string _location;
        public string location
        {
            get => _location;
            set
            {
                if (value != "" && value != null)
                {
                    _location = value;
                };
            }
        }


    }
}

