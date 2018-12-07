using FirstNetCoreMvcSY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.Repositories
{
    public interface ICartRepository
    {
        void AddCart(Product product);
        void RemoveFromCart(int id);
        void CleanCart();
        List<Product> GetCart();
    }
}
