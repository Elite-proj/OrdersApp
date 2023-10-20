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
    public class OrderLineController : Controller
    {
        public readonly IConfiguration _IConfiguration;
        DataAccessLayer data;
        DataTable dt;

        public OrderLineController(IConfiguration config)
        {
            this._IConfiguration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();

            dt=data.GetProductType();

            List<ProductType> productTypes = new List<ProductType>();
            
            for(int i=0;i<dt.Rows.Count;i++)
            {
                ProductType productType = new ProductType();

                productType.ProductTypeID = int.Parse(dt.Rows[i]["ProductTypeID"].ToString());
                productType.ProductTypeDescription = dt.Rows[i]["ProductTypeDescription"].ToString();

                productTypes.Add(productType);
            }

            var getTypes = productTypes.ToList();

            ViewBag.Types = new SelectList(getTypes, "ProductTypeID", "ProductTypeDescription");

            return View();
        }

        [HttpPost]
        public IActionResult Add(OrderLine line)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            if (ModelState.IsValid)
            {

                #region Line number increament
                int ordersID = (int)HttpContext.Session.GetInt32("OrdersID");

                dt = new DataTable();

                dt = data.GetLineNumberCount(ordersID);
                int counter;

                try
                {
                    counter = int.Parse(dt.Rows[0]["CounterCol"].ToString());
                }
                catch
                {
                    counter = 0;
                }

                counter++;
                

                #endregion

                line.LineNumber = counter;

                data.AddOrderLine(line);

                return RedirectToAction("List", "Order");
            }
            else
            {
                dt = new DataTable();

                dt = data.GetProductType();

                List<ProductType> productTypes = new List<ProductType>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductType productType = new ProductType();

                    productType.ProductTypeID = int.Parse(dt.Rows[i]["ProductTypeID"].ToString());
                    productType.ProductTypeDescription = dt.Rows[i]["ProductTypeDescription"].ToString();

                    productTypes.Add(productType);
                }

                var getTypes = productTypes.ToList();

                ViewBag.Types = new SelectList(getTypes, "ProductTypeID", "ProductTypeDescription");

                return View(line);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);

            dt = new DataTable();

            dt = data.GetOrderLineByID(id);

            OrderLine line = new OrderLine();
            if (dt.Rows.Count>0)
            {
                
                line.ProductCode = dt.Rows[0]["ProductCode"].ToString();
                line.LineNumber = int.Parse(dt.Rows[0]["LineNumber"].ToString());
                line.ProductTypeID = int.Parse(dt.Rows[0]["ProductTypeID"].ToString());
                line.ProductCostPrice = double.Parse(dt.Rows[0]["ProductCostPrice"].ToString());
                line.ProductSalePrice = double.Parse(dt.Rows[0]["ProductSalePrice"].ToString());
                line.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                line.OrdersID= int.Parse(dt.Rows[0]["OrdersID"].ToString());
                line.OrderLineID= int.Parse(dt.Rows[0]["OrderLineID"].ToString());
            }

            DataTable dtType = new DataTable();
            dtType = data.GetProductType();

            List<ProductType> productTypes = new List<ProductType>();

            for (int i = 0; i < dtType.Rows.Count; i++)
            {
                ProductType productType = new ProductType();

                productType.ProductTypeID = int.Parse(dtType.Rows[i]["ProductTypeID"].ToString());
                productType.ProductTypeDescription = dtType.Rows[i]["ProductTypeDescription"].ToString();

                productTypes.Add(productType);
            }

            var getTypes = productTypes.ToList();

            ViewBag.Types = new SelectList(getTypes, "ProductTypeID", "ProductTypeDescription");

            return View(line);
        }

        [HttpPost]
        public IActionResult Edit(OrderLine line)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);

            if(ModelState.IsValid)
            {
                data.UpdateOrderLine(line);
                int id = (int)HttpContext.Session.GetInt32("OrdersID");
                return RedirectToAction("Details", "Order", new { id=id});
            }
            else
            {
                dt = new DataTable();
                dt = data.GetProductType();

                List<ProductType> productTypes = new List<ProductType>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductType productType = new ProductType();

                    productType.ProductTypeID = int.Parse(dt.Rows[i]["ProductTypeID"].ToString());
                    productType.ProductTypeDescription = dt.Rows[i]["ProductTypeDescription"].ToString();

                    productTypes.Add(productType);
                }

                var getTypes = productTypes.ToList();

                ViewBag.Types = new SelectList(getTypes, "ProductTypeID", "ProductTypeDescription");

                return View(line);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);
            dt = new DataTable();

            dt = data.GetOrderLineByID(id);

            OrderLine line = new OrderLine();
            if (dt.Rows.Count > 0)
            {

                line.ProductCode = dt.Rows[0]["ProductCode"].ToString();
                line.LineNumber = int.Parse(dt.Rows[0]["LineNumber"].ToString());
                line.ProductTypeID = int.Parse(dt.Rows[0]["ProductTypeID"].ToString());
                line.ProductCostPrice = double.Parse(dt.Rows[0]["ProductCostPrice"].ToString());
                line.ProductSalePrice = double.Parse(dt.Rows[0]["ProductSalePrice"].ToString());
                line.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                line.OrdersID = int.Parse(dt.Rows[0]["OrdersID"].ToString());
                line.OrderLineID = int.Parse(dt.Rows[0]["OrderLineID"].ToString());
            }

            return View(line);
        }

        [HttpPost]
        public IActionResult Delete(OrderLine line)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }

            data = new DataAccessLayer(_IConfiguration);

            data.DeleteOrderLine(line);

            int id = (int)HttpContext.Session.GetInt32("OrdersID");

            return RedirectToAction("Details", "Order", new { id = id });
        }
    }
}
