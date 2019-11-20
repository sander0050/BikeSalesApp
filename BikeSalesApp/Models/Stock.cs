using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public Store Stores { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public Product Products { get; set; }

        public int Quantity { get; set; }
    }
}