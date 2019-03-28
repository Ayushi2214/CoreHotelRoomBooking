using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCoreHotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCoreHotel.Controllers
{
    public class HotelRoomController : Controller
    {
        CoreHotelRoomBookingContext context = new CoreHotelRoomBookingContext();
        public IActionResult Index()
        {
            var hotelroom = context.HotelRooms.ToList();
            return View(hotelroom);
        }
        public ViewResult ViewDetails(int id)
        {
            HotelRooms hotelRooms = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelRooms;
            int hid = ViewBag.HotelRoom.HotelId;
            Hotels hotels = context.Hotels.Where(x => x.HotelId == hid).SingleOrDefault();
            ViewBag.Hotel = hotels;
            RoomFacilities roomFacilities = context.RoomFacilities.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.RoomFacility = roomFacilities;
            return View();
        }
        public ViewResult Details(int id)
        {
            var hotelroom = context.HotelRooms.Where(x => x.HotelId == id).ToList();
            return View(hotelroom);
        }
    }
}