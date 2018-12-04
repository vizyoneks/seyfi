using FirstNetCoreMvcSY.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }

        public List<SelectListItem> Brands { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Merco", Text = "Merco" },
        new SelectListItem { Value = "BMW", Text = "BMW" },
        new SelectListItem { Value = "Porche", Text = "Porche"  },
    };

        public IFormFile File { get; set; }

    }
}
