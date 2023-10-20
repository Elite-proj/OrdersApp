using Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    
    public class OrderController : Controller
    {
        private OrderContext context { get; set; }

        public OrderController(OrderContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            

            ViewBag.Action = "Add Order";

            var types= context.orderTypes.OrderBy(o => o.TypeDescription).ToList();
            ViewBag.OrderType = new SelectList(types, "OrderTypeID", "TypeDescription");

            var Status= context.orderStatuses.OrderBy(s => s.StatusDescription).ToList();

            ViewBag.OrderStatus = new SelectList(Status, "OrderStatusID", "StatusDescription");

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            var types = context.orderTypes.OrderBy(o => o.TypeDescription).ToList();
            ViewBag.OrderType = new SelectList(types, "OrderTypeID", "TypeDescription");

            var Status = context.orderStatuses.OrderBy(s => s.StatusDescription).ToList();

            ViewBag.OrderStatus = new SelectList(Status, "OrderStatusID", "StatusDescription");

            var Orders = context.orders.Find(id);

            return View(Orders);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            var Orders = context.orders.Find(id);

            return View(Orders);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            if (HttpContext.Session.GetInt32("OrdersID")!=null)
            {
                HttpContext.Session.Remove("OrdersID");
            }

            HttpContext.Session.SetInt32("OrdersID", id);

            var OrderLine = context.orderLines.Where(o => o.OrdersID == id).Where(s=>s.DeleteStatus=="Active").Include(t => t.ProductType).OrderBy(d => d.OrderLineID);

            return View(OrderLine);
        }

        [HttpGet]
        public IActionResult List()
        {
           

            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            if (HttpContext.Session.GetInt32("OrdersID")!=null)
            {
                HttpContext.Session.Remove("OrdersID");
            }

            var Orders = context.orders.Where(d=>d.DeleteStatus=="Active").Include(t => t.OrderType).Include(s => s.OrderStatus).OrderBy(o => o.OrdersID);

            return View(Orders);
        }

        [HttpPost]
        public IActionResult Add(Orders orders )
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                context.orders.Add(orders);

                context.SaveChanges();

                return RedirectToAction("List", "Order");
            }
            else
            {
                ViewBag.OrderType = context.orderTypes.OrderBy(o => o.TypeDescription).ToList();

                ViewBag.OrderStatus = context.orderStatuses.OrderBy(s => s.StatusDescription).ToList();

                return View(orders);
            }
        }

        [HttpPost]
        public IActionResult Edit(Orders orders)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                context.orders.Update(orders);

                context.SaveChanges();

                return RedirectToAction("List", "Order");
            }
            else
            {
                ViewBag.OrderType = context.orderTypes.OrderBy(o => o.TypeDescription).ToList();

                ViewBag.OrderStatus = context.orderStatuses.OrderBy(s => s.StatusDescription).ToList();

                return View(orders);
            }
        }

        [HttpPost]
        public IActionResult Delete(Orders orders)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            context.orders.Update(orders);

            context.SaveChanges();

            return RedirectToAction("List", "Order");
        }
    }
}
