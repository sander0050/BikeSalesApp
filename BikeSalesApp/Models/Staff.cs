using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public Store Stores { get; set; }

    }
}