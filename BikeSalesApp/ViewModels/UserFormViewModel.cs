using BikeSalesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSalesApp.ViewModels
{
    public class UserFormViewModel
    {
        public ApplicationUser User { get; set; }
        public List<RolesSelected> Roles { get; set; }
    }
}