using FirstNetCoreMvcSY.Repositories;
using FirstNetCoreMvcSY.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHostingEnvironment environment;
        private readonly IProductRepository productRepository;

        public ProductController(IHostingEnvironment environment, IProductRepository productRepository)
        {
            this.environment = environment;
            this.productRepository = productRepository;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductViewModel();
            model.Products = productRepository.GetAll();
            model.Brands = productRepository.GetBrands();
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new ProductCreateViewModel() {Brands = productRepository.GetBrands() });
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (model.File.Length > 0)
                {
                    var filePath = Path.Combine(environment.WebRootPath, @"Images",model.File.FileName);
                    var x = Path.Combine(Directory.GetCurrentDirectory(), @"Images");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.File.CopyToAsync(stream);
                        model.Product.ImagePath = model.File.FileName;
                    }
                }
                try
                {
                    productRepository.Create(model.Product);
                }
                catch (Exception ex)
                {
                    
                }
                

                return RedirectToAction(nameof(Create));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}