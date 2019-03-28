using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerCoreHotel.Models;

namespace CustomerCoreHotel.Controllers
{
    public class HomeController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();
        

        public IActionResult Index()
        {
            var hotels = context.Hotels.ToList();
            return View(hotels);
        }
        public ViewResult Details(int id)
        {
            Hotels hotels = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotels;
            return View();
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string search)
        {
            ViewBag.Hotel = context.Hotels.Where(x => x.HotelName == search || x.City == search || x.State == search || search == null).ToList();
            return View(context.Hotels.Where(x => x.HotelName == search || search == null).ToList());
        }


    }
}
