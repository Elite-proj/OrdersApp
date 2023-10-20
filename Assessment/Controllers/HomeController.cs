using Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private OrderContext context { get; set; }

        public HomeController(OrderContext ctx)
        {
            context = ctx;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}



        public IActionResult Index()
        {
            var UserRole = context.userRoles.OrderBy(r => r.UserRoleDescription);

            ViewBag.UserRoles = new SelectList(UserRole, "UserRoleID", "UserRoleDescription");

            return View();
        }

        public async Task<IActionResult> APICall()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dog.ceo/dog-api/");
                

                using (HttpResponseMessage response = await client.GetAsync(""))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    APIClass aPI = new APIClass();
                    aPI.Content = responseContent.ToString();
                    return View(aPI);
                }
            }
           
        }


        [HttpPost]
        public IActionResult Index(AppUsers user)
        {
            if(ModelState.IsValid)
            {
                context.AppUsers.Add(user);

                context.SaveChanges();

                return RedirectToAction("Login", "Home");
            }
            else
            {
                var UserRole = context.userRoles.OrderBy(r => r.UserRoleDescription);

                ViewBag.UserRoles = new SelectList(UserRole, "UserRoleID", "UserRoleDescription");

                return View(user);
            }
        }
        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                
                var dt2 = context.AppUsers.Where(u => u.EmailAddress == login.EmailAddress && u.Password == login.Password).Include(t => t.UserRole);

               
                foreach(var user in dt2)
                {
                    HttpContext.Session.Remove("Guest");
                    HttpContext.Session.Remove("Admin");

                    if (user.UserRole.UserRoleDescription== "Guest")
                    {
                        HttpContext.Session.SetString("Guest", "True");

                        return RedirectToAction("List", "Order", new { area = "Guest" });
                    }
                    else if(user.UserRole.UserRoleDescription == "Admin")
                    {
                        HttpContext.Session.SetString("Admin", "True");

                        return RedirectToAction("List", "Order");
                        
                    }
                    else
                    {
                        
                        ModelState.AddModelError("", "Invalid username/password");

                        return View(login);
                    }
                }

                ModelState.AddModelError("", "Invalid username/password");

                return View(login);


            }
            else
            {
                ModelState.AddModelError("", "Invalid username/password");

                return View(login);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
