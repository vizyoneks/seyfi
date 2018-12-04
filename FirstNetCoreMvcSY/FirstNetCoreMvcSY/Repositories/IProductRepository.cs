using FirstNetCoreMvcSY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product GetById(int id);

        List<Product> SearchByName(string searchText);

        void Create(Product product);

        void Delete(int id);
        
    }
}
