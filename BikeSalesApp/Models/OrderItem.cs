using System;
using System.Collections.Generic;
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

        public int ProductId { get; set; }
        public Product Products { get; set; }

        public int OrderId { get; set; }
        public Order Orders { get; set; }

    }
}