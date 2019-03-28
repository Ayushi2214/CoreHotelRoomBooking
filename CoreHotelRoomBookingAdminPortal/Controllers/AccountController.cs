using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreHotelRoomBookingAdminPortal.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")] //default route for Index 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username!= null && password!= null && username.Equals("admin") && password.Equals("123456"))
            {
                HttpContext.Session.SetString("username", username); //to print ""Welcome "user's Name" ""
                return View("Home");

            }
            else {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");

            }
            
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}