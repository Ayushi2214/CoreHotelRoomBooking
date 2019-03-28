



using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelType
    {
        [Required]
        public int HotelTypeId { get; set; }
        [Required]
        public string HotelTypeName { get; set; }
        [Required]
        public string HotelTypeDescription { get; set; }


        public List<Hotel> Hotels { get; set; }
    }
}
