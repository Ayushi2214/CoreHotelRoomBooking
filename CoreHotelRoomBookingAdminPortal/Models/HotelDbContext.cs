
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelDbContext : DbContext
    {

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<roomFacility> RoomFacilities { get; set; }
        public DbSet<HotelType> HotelTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=TRD-514;Initial Catalog=CoreHotelRoomBooking;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>(build =>
            {
                build.HasKey(t => new { t.BookingId, t.RoomId });
            }

           );
        }
        //protected override OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookingDetail>(build =>
        //    {
        //        build.HasKey(t => new { t.BookingId, t.RId });
        //    }

        //    );
        //}


    }
}
