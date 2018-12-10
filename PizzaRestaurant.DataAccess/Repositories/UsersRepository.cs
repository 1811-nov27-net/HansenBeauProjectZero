using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaRestaurant.DataAccess
{
    public class UsersRepository : IUserRepository
    {
        private readonly PizzaOrdersContext _dataBase;

        public UsersRepository(PizzaOrdersContext dataBase)
        {
            _dataBase = dataBase ?? throw new ArgumentNullException(nameof(dataBase));
        }

        public void AddUser(User user) => _dataBase.Add(user);

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user) => _dataBase.Remove(user);


        //public List<User> GetUsers()
        //{
        //    return _dataBase.Users.AsNoTracking();
        //}

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
