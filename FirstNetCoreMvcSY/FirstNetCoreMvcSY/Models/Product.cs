using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name="Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Stok")]
        public int Balance { get; set; }

        [Display(Name = "Ürün Resmi")]
        public string ImagePath { get; set; }

        [Display(Name = "Marka")]
        public int Brand { get; set; }
    }
}
