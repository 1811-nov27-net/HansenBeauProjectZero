using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;
using System.Linq;

namespace PizzaRestaurant.DataAccess
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PizzaOrdersContext _db;

        public AddressRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Library.Address> GetAddresses()
        {
            return Mapper.Map(_db.Address);
        }
    }
}
