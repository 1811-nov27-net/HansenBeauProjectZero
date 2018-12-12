using System;
using System.Collections.Generic;
using System.Text;
using PizzaRestaurant.Library;
using System.Linq;

namespace PizzaRestaurant.DataAccess
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PizzaOrdersContext _db;

        public ProductsRepository(PizzaOrdersContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Product GetProductByID(int productId)
        {
            IEnumerable<Product> productCollection = Mapper.Map(_db.Products);
            return productCollection.Where(p => p.productID == productId).First();
        }

        public IEnumerable<Product> GetProducts()
        {
            return Mapper.Map(_db.Products);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
