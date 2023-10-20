using Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    public class SearchController : Controller
    {
        public readonly IConfiguration _IConfiguration;
        DataAccessLayer data;
        DataTable dt;

        public SearchController(IConfiguration config)
        {
            this._IConfiguration = config;
        }

        [HttpGet]
        public IActionResult SearchOrdersBetweenDates()
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest")==null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        public IActionResult SearchOrdersBetweenDates(BetweenDatesViewModel dates)
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();

            if(ModelState.IsValid)
            {
                dt = data.SearchOrdersBetweenDates(dates.MinDate, dates.MaxDate);

                if(dt.Rows.Count>0)
                {
                    List<Orders> orders = new List<Orders>(); 
                    
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        Orders order = new Orders();

                        order.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                        order.OrderNumber = int.Parse(dt.Rows[i]["OrderNumber"].ToString());
                        order.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());

                        orders.Add(order);
                    }

                    var OderList = orders.ToList();

                    return View("ListOrderResults", OderList);

                }
                else
                {
                    ModelState.AddModelError("", "Results not found");
                    return View(dates);
                }
                   

            }
            else
            {
                ModelState.AddModelError("", "Results not found");
                return View(dates);
            }
               

        }

        [HttpGet]
        public IActionResult SearchOrdersByType()
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();

            dt = data.GetOrderTypes();

            List<OrderType> orderTypes = new List<OrderType>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                OrderType orderType = new OrderType();
                orderType.OrderTypeID = int.Parse(dt.Rows[i]["OrderTypeID"].ToString());
                orderType.TypeDescription = dt.Rows[i]["TypeDescription"].ToString();

                orderTypes.Add(orderType);
            }

            var types = orderTypes.ToList();

            ViewBag.Types = new SelectList(types, "OrderTypeID", "TypeDescription");

            return View();
        }

        [HttpPost]
        public IActionResult SearchOrdersByType(OrderType type)
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();
            if(ModelState.IsValid)
            {
                dt = data.SearchOrdersByType(type);

                if (dt.Rows.Count > 0)
                {
                    List<Orders> orders = new List<Orders>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Orders order = new Orders();

                        order.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                        order.OrderNumber = int.Parse(dt.Rows[i]["OrderNumber"].ToString());
                        order.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());

                        orders.Add(order);
                    }

                    var OderList = orders.ToList();

                    return View("ListOrderResults", OderList);

                }
                else
                {
                    dt = data.GetOrderTypes();

                    List<OrderType> orderTypes = new List<OrderType>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderType orderType = new OrderType();
                        orderType.OrderTypeID = int.Parse(dt.Rows[i]["OrderTypeID"].ToString());
                        orderType.TypeDescription = dt.Rows[i]["TypeDescription"].ToString();

                        orderTypes.Add(orderType);
                    }

                    var types = orderTypes.ToList();

                    ViewBag.Types = new SelectList(types, "OrderTypeID", "TypeDescription");

                    ModelState.AddModelError("", "Results not found");
                    return View(type);
                }


            }
            else
            {
                dt = data.GetOrderTypes();

                List<OrderType> orderTypes = new List<OrderType>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderType orderType = new OrderType();
                    orderType.OrderTypeID = int.Parse(dt.Rows[i]["OrderTypeID"].ToString());
                    orderType.TypeDescription = dt.Rows[i]["TypeDescription"].ToString();

                    orderTypes.Add(orderType);
                }

                var types = orderTypes.ToList();

                ViewBag.Types = new SelectList(types, "OrderTypeID", "TypeDescription");

                ModelState.AddModelError("", "Results not found");
                return View(type);
            }
        
        }

        [HttpGet]
        public IActionResult SearchOrderLineByProductCode()
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        public IActionResult SearchOrderLineByProductCode(SearchOrderLineVM search)
        {
            if (HttpContext.Session.GetString("Admin") == null || HttpContext.Session.GetString("Guest") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();

            if(ModelState.IsValid)
            {
                dt = data.SearchOrderLineByProductCode(search);

                if (dt.Rows.Count > 0)
                {
                    List<OrderLine> orderLines = new List<OrderLine>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        OrderLine orderLine = new OrderLine();

                        orderLine.LineNumber= int.Parse(dt.Rows[i]["LineNumber"].ToString());
                        orderLine.ProductCode= dt.Rows[i]["ProductCode"].ToString();
                        orderLine.ProductCostPrice = double.Parse(dt.Rows[i]["ProductCostPrice"].ToString());
                        orderLine.ProductSalePrice= double.Parse(dt.Rows[i]["ProductSalePrice"].ToString());
                        orderLine.Quantity= int.Parse(dt.Rows[i]["Quantity"].ToString());
                        orderLine.OrdersID= int.Parse(dt.Rows[i]["OrdersID"].ToString());

                        orderLines.Add(orderLine);
                    }

                    var OrderLineList = orderLines.ToList();

                    return View("OrderLinesResults", OrderLineList);

                }
                else
                {
                    ModelState.AddModelError("", "Results not found");
                    return View(search);
                }

            }
            else
            {
                ModelState.AddModelError("", "Results not found");
                return View(search);
            }
        }
    }
}
