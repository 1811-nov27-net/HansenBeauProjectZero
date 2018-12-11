using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaRestaurant.DataAccess
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly PizzaOrdersContext _db;

        public UserRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void DeleteUser(int userID)
        {
            _db.Remove(_db.Users.Find(userID));
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
            // return _db.Users.ToList();
        }

        public User GetUsersByName(string fName, string lName)
        {
            throw new NotImplementedException();
            // return _db.Users.ToList();
        }

        public void InsertUser(User user)
        {
            _db.Add(Mapper.Map(user));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
