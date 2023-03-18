using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public class Hotel_Manager
    {
        
        //public int ID { get; set; }

        [Key]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("Hotel")]
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

    }
}
