﻿using System;
using System.Collections.Generic;

namespace CustomerCoreHotel.Models
{
    public partial class Hotels
    {
        public Hotels()
        {
            HotelRooms = new HashSet<HotelRooms>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelImage { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string HotelEmailId { get; set; }
        public string HotelRating { get; set; }
        public int HotelContactNumber { get; set; }
        public string HotelDescription { get; set; }
        public int HotelTypeId { get; set; }
        public string District { get; set; }

        public HotelTypes HotelType { get; set; }
        public ICollection<HotelRooms> HotelRooms { get; set; }
    }
}
