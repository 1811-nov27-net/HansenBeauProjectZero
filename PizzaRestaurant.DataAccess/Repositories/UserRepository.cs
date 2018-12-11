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
            return Mapper.Map(_db.Users);
        }

        public IEnumerable<User> GetUsersByName(string fName, string lName)
        {
            return Mapper.Map(_db.Users.Where(u => u.FirstName == fName && u.LastName == lName));
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
