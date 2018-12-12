using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaRestaurant.Library
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
        void Save();
    }
}
