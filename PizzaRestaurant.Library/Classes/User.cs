using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaRestaurant.Library
{
    public class User
    {
        public User(string inputfName, string inputlName)
        {
            _fName = inputfName;
            _lName = inputlName;
        }

        private int _userId;
        public int userId
        {
            get => _userId;
            set => _userId = value;
        }

        private string _fName;
        public string fName
        {
            get => _fName;
            set
            {
                try
                {
                    _fName = value ?? throw new ArgumentNullException(nameof(value));
                }
                catch (ArgumentNullException)
                {

                    _fName = "";
                }
            }
        }
        /// <summary>
        /// Initializes lName as public property with private back storage.
        /// Simple exception handling with null argument
        /// </summary>
        private string _lName;
        public string lName
        {
            get => _lName;
            set
            {
                try
                {
                    _lName = value ?? throw new ArgumentNullException(nameof(value));
                }
                catch (ArgumentNullException)
                {

                    _lName = "";
                }
            }
        }

        /// <summary>
        /// Initializes lastOrderTime as public property with private back storage.
        /// </summary>
        private DateTime _lastOrderTime;
        public DateTime lastOrderTime
        {
            get => _lastOrderTime;
            set => _lastOrderTime = value;
        }
    }
}
