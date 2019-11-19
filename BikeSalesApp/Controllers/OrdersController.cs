using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSalesApp.Models;
using BikeSalesApp.ViewModels;

namespace BikeSalesApp.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private OrderFormViewModel ViewModel = new OrderFormViewModel();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customers).Include(o => o.Staffs);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Order order = db.Orders.Find(id);
            List<OrderItem> orderItem = db.OrderItems.ToList().FindAll(c => c.OrderId == id);


            if (order == null)
            {
                return HttpNotFound();
            }

            ViewModel = new OrderFormViewModel()
            {
                Order = order,
                OrderItem = orderItem,
                Customers = db.Customers.ToList(),
                Staffs = db.Staffs.ToList()
            };
            return View(ViewModel);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {

            ViewModel.Customers = db.Customers.ToList();
            ViewModel.Staffs = db.Staffs.ToList();

            return View("OrderForm", ViewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult AddOrderItem()
        {
            ViewBag.OrderId = ViewModel.Order.OrderId;
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View("AddOrderItem");
        }

   
        [ValidateAntiForgeryToken]
        public ActionResult AddOrderItem(OrderItem Item)
        {
            ViewModel.OrderItem.Add(Item);

            ViewModel.Customers = db.Customers.ToList();
            ViewModel.Staffs = db.Staffs.ToList();

            return View("OrderForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(OrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewModel.Customers = db.Customers.ToList();
                ViewModel.Staffs = db.Staffs.ToList();
                return View("OrderForm", ViewModel);

            }

            if (model.Order.OrderId == 0)
            {

                db.Orders.Add(model.Order);
                db.SaveChanges();


            }
            else {
                var orderInDb = db.Orders.Single(m => m.OrderId == model.Order.OrderId);
                orderInDb.OrderStatus = model.Order.OrderStatus;
                orderInDb.RequiredDate = model.Order.RequiredDate;
                orderInDb.ShippedDate = model.Order.ShippedDate;
                orderInDb.CustomerId = model.Order.CustomerId;
                orderInDb.StaffId = model.Order.StaffId;

                var orderItemInDb = db.OrderItems.Single(m => m.OrderId == model.Order.OrderId);

                List<OrderItem> orderItem = db.OrderItems.ToList().FindAll(c => c.OrderId == model.Order.OrderId);

                foreach (var item in orderItem)
                {
                    db.OrderItems.Remove(item);
                }
                db.SaveChanges();
            }

            foreach (var item in model.OrderItem)
            {
                item.OrderId = model.Order.OrderId;
                db.OrderItems.Add(item);
            }
            db.SaveChanges();



            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Order order = db.Orders.Find(id);
            List<OrderItem> orderItem = db.OrderItems.ToList().FindAll(c => c.OrderId == id);
            

            if (order == null)
            {
                return HttpNotFound();
            }

            ViewModel = new OrderFormViewModel()
            {
                Order = order,
                OrderItem = orderItem,
                Customers = db.Customers.ToList(),
                Staffs = db.Staffs.ToList()
            };

            return View("OrderForm", ViewModel);

        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewModel.Customers = db.Customers.ToList();
            ViewModel.Staffs = db.Staffs.ToList();
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
