using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ModelYear { get; set; }
        public double ListPrice { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public Brand Brands { get; set; }
    }
}