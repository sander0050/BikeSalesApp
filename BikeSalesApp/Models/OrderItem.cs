using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double ListPrice { get; set; }
        public double Discount { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public Product Products { get; set; }

        [Display(Name = "Order")]
        public int OrderId { get; set; }
        public Order Orders { get; set; }

    }
}