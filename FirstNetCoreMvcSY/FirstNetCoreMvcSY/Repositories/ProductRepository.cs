using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCoreMvcSY.Models;

namespace FirstNetCoreMvcSY.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public void Create(Product product)
        {
            int maxId;
            try
            {
                maxId = _products.Max(en => en.Id) + 1;
            }
            catch (Exception)
            {
                maxId = 1;
            }
            product.Id = maxId;
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _products.Remove(product);
        }

        public List<Product> GetAll() => _products.ToList();

        public Product GetById(int id) => _products.First(en => en.Id == id);

        public List<Product> SearchByName(string searchText)
        {
            return _products.Where(p => p.Name.ToLower() == searchText.ToLower()).ToList();
        }
    }
}
