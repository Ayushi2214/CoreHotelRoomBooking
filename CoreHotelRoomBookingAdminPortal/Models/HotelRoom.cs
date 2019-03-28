using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotelRoomBookingAdminPortal.Models
{
    public class HotelRoom
   
        {
            [Key]
            [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
            public int RoomId { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public int RoomPrice { get; set; }
        [Required]
        public string RoomDescription { get; set; }
       
        public string RoomImage { get; set; }

          //[ForeignKey("HotelId")]
           public int HotelId { get; set; }

          //[ForeignKey("RoomFacilityId")]
          
            public roomFacility roomFacility { get; set; }
            public Hotel Hotel { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }


    }
 }
