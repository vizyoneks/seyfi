using FirstNetCoreMvcSY.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public List<SelectListItem> Brands { get; set; }

    }
}
