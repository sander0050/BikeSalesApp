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
        public List<OrderItem> OrderItem { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Staff> Staffs { get; set; }

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
                OrderDate = DateTime.Now,
                OrderStatus = "PENDING"
                
            };

            OrderItem = new List<OrderItem>();
        }

        public OrderFormViewModel(Order order)
        {
            this.Order = order;
            this.OrderItem = new List<OrderItem>();
        }

        public OrderFormViewModel(Order order, List<OrderItem> orderItem)
        {
            this.Order = order;
            this.OrderItem = orderItem;
        }
    }
}