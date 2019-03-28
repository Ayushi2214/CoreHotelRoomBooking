using System.Collections.Generic;
using System.Linq;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HotelRoomBooking.Controllers
{
    public class RoomFacilityController : Controller
    {
        HotelDbContext context;
        public RoomFacilityController(HotelDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var roomfacilities = context.RoomFacilities.ToList();
            return View(roomfacilities);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotels = new SelectList(context.HotelRooms, "RoomId", "RoomId");
            return View();
        }
        [HttpPost]
        public IActionResult Create(roomFacility hf1)
        {
            context.RoomFacilities.Add(hf1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            roomFacility roomfacility = context.RoomFacilities.Find(id);
            ViewBag.hotels = new SelectList(context.HotelRooms, "RoomId", "RoomId");
            return View(roomfacility);
        }
        [HttpPost]
        public ActionResult Delete(int id, roomFacility hf1)
        {
            var roomfacility = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            context.RoomFacilities.Remove(roomfacility);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            roomFacility roomfacility = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            ViewBag.hotels = new SelectList(context.HotelRooms, "RoomId", "RoomId", roomfacility.RoomId);
            return View(roomfacility);
        }
        [HttpPost]
        public ActionResult Edit(roomFacility hf1)
        {
            roomFacility roomfacility = context.RoomFacilities.Where(x => x.RoomFacilityId == hf1.RoomFacilityId).SingleOrDefault();
            roomfacility.RoomFacilityId = hf1.RoomFacilityId;
            roomfacility.IsAvailable = hf1.IsAvailable;
            roomfacility.Wifi = hf1.Wifi;
            roomfacility.Ekettle = hf1.Ekettle;
            roomfacility.Refrigerator = hf1.Refrigerator;
            roomfacility.AirConditioner = hf1.AirConditioner;
            roomfacility.RoomFacilityDescription = hf1.RoomFacilityDescription;
            roomfacility.RoomId = hf1.RoomId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ViewResult Details(int id)
        {
            roomFacility roomfacility = context.RoomFacilities.
                Where(x => x.RoomFacilityId == id).SingleOrDefault();
            return View(roomfacility);

        }
    }
}
    
