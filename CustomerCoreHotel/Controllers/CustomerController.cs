using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCoreHotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }




        [Route("mylogin")]
        [HttpPost]
        public IActionResult MyLogin(string username, string password)
        {
            var user = context.Customers.Where(x => x.EmailId == username).SingleOrDefault();
            ViewBag.cust = user;
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.EmailId;
                int custId = ViewBag.cust.CustomerId;
                //var passWord = user.UserPassword;
                if (username != null && password != null && username.Equals(userName) && password.Equals("12345"))
                {
                    HttpContext.Session.SetString("uname", username);
                    return RedirectToAction("CheckOut", "Book", new { @id = custId });
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers c1)
        {
            context.Customers.Add(c1);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }
    }
}
