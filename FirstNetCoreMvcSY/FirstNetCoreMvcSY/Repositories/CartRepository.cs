using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCoreMvcSY.Models;
using Microsoft.AspNetCore.Http;
using FirstNetCoreMvcSY.Extensions;

namespace FirstNetCoreMvcSY.Repositories
{
    public class CartRepository : ICartRepository
    {
        private const string _PRODUCT_KEY = "CART_PRODUCTS";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly List<Product> products;

        public CartRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddCart(Product product)
        {
            var model = _httpContextAccessor.HttpContext.Session.Get<List<Product>>(_PRODUCT_KEY);

            if (model == null)
            {
                model = new List<Product>() { product };
                _httpContextAccessor.HttpContext.Session.Set(_PRODUCT_KEY, model);
            }
            else
            {
                model.Find(x => x.Id == product.Id).Balance++;

                _httpContextAccessor.HttpContext.Session.Set(_PRODUCT_KEY, model);
            }
        }

        public void CleanCart()
        {
            var model = _httpContextAccessor.HttpContext.Session.Get<List<Product>>(_PRODUCT_KEY);
            if (model != null)
            {
                _httpContextAccessor.HttpContext.Session.Set(_PRODUCT_KEY, null);
            }
        }

        public List<Product> GetCart()
        {
            return _httpContextAccessor.HttpContext.Session.Get<List<Product>>(_PRODUCT_KEY);
        }

        public void RemoveFromCart(int id)
        {
            var model = _httpContextAccessor.HttpContext.Session.Get<List<Product>>(_PRODUCT_KEY);
            if (model != null)
            {
                model.Remove(model.Find(x => x.Id == id));
                _httpContextAccessor.HttpContext.Session.Set(_PRODUCT_KEY, model);
            }
        }
    }
}
