using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;

namespace PizzaRestaurant.DataAccess
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PizzaOrdersContext _db;

        public ProductsRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Product> GetProducts()
        {
            return Mapper.Map(_db.Products);
        }
    }
}
