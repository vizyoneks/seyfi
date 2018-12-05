using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCoreMvcSY.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstNetCoreMvcSY.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CoreDb _context;

        public ProductRepository(CoreDb context)
        {
            this._context = context;
        }

        public void Create(Product product)
        {
            int maxId;
            try
            {
                maxId = _context.Products.Max(en => en.Id) + 1;
            }
            catch (Exception)
            {
                maxId = 1;
            }
            //product.Id = maxId;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id) => _context.Products.First(en => en.Id == id);

        public List<Product> SearchByName(string searchText)
        {
            return _context.Products.Where(p => p.Name.ToLower() == searchText.ToLower()).ToList();
        }

        public List<SelectListItem> GetBrands()
        {
            return new List<SelectListItem> {
                new SelectListItem { Value = "1", Text = "Renault" },
                new SelectListItem { Value = "2", Text = "Mercedes" },
                new SelectListItem { Value = "3", Text = "BMW" },
                new SelectListItem { Value = "4", Text = "Citroen" },
                new SelectListItem { Value = "5", Text = "Honda" }

            };
        }

    }
}
