using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.DataAccess
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PizzaOrdersContext _db;

        public StoreRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Library.Store GetStoreByID(int storeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Store> GetStores()
        {
            return Mapper.Map(_db.Store);
        }
    }
}
