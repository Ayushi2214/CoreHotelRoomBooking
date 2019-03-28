using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelRoomController : Controller

    {
        HotelDbContext context;
        public HotelRoomController(HotelDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var hotelrooms = context.HotelRooms.ToList();

            return View(hotelrooms);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelRoom hr1)
        {
            context.HotelRooms.Add(hr1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Find(id);
            return View(hotelroom);
        }
        [HttpPost]
        public ActionResult Delete(int id, HotelRoom hr1)
        {
            var hotelroom = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            context.Hotels.Remove(hotelroom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.hotels = new SelectList(context.Hotels, "HotelId", "HotelName", hotelroom.HotelId);
            
            return View(hotelroom);
        }
        [HttpPost]
        public ActionResult Edit(HotelRoom h1)
        {
            HotelRoom hotelroom = context.HotelRooms.Where(x => x.RoomId == h1.RoomId).SingleOrDefault();
            hotelroom.RoomId = h1.RoomId;
            hotelroom.RoomType = h1.RoomType;
            hotelroom.RoomPrice = h1.RoomPrice;
            hotelroom.RoomImage = h1.RoomImage;
            hotelroom.RoomDescription = h1.RoomDescription;
            hotelroom.HotelId = h1.HotelId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.
                Where(x => x.RoomId == id).SingleOrDefault();
            return View(hotelroom);

        }
    }
}
