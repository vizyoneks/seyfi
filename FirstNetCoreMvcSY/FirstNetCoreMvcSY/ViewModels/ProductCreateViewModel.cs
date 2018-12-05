using FirstNetCoreMvcSY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FirstNetCoreMvcSY.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }

        public List<SelectListItem> Brands { get; set; }

        public IFormFile File { get; set; }

    }
}
