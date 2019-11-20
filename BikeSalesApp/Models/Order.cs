using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        [Display(Name = "Staff")]
        public int StaffId { get; set; }
        public Staff Staffs { get; set; }



    }
}