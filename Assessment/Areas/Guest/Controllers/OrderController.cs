using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Guest.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private OrderContext context { get; set; }

        public OrderController(OrderContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
           

            if (HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
           

            if (HttpContext.Session.GetInt32("OrdersID") != null)
            {
                HttpContext.Session.Remove("OrdersID");
            }

            var Orders = context.orders.Where(d => d.DeleteStatus == "Active").Include(t => t.OrderType).Include(s => s.OrderStatus).OrderBy(o => o.OrdersID);

            return View(Orders);
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            if (HttpContext.Session.GetInt32("OrdersID") != null)
            {
                HttpContext.Session.Remove("OrdersID");
            }

            HttpContext.Session.SetInt32("OrdersID", id);

            var OrderLine = context.orderLines.Where(o => o.OrdersID == id).Where(s => s.DeleteStatus == "Active").Include(t => t.ProductType).OrderBy(d => d.OrderLineID);

            return View(OrderLine);
        }
    }
}
