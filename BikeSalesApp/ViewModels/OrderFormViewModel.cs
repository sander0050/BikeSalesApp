using BikeSalesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSalesApp.ViewModels
{
    public class OrderFormViewModel
    {
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }

        public string Title
        {
            get
            {
                return Order.OrderId != 0 ? "Edit Order" : "New Order";
            }
        }


        public OrderFormViewModel()
        {
            Order = new Order()
            {
                OrderId = 0,
                OrderDate = DateTime.Today,
                OrderStatus = "PENDING"
                
            };
        }

        public OrderFormViewModel(Order order)
        {
            this.Order = order;
        }
    }
}