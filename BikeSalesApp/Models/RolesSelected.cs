using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSalesApp.Models
{
    public class RolesSelected
    {
        public IdentityRole Role { get; set; }
        public bool IsSelected { get; set; }
    }

}