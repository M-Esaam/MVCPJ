using RepositoryModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public class Customer
    {

        [Key]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
       
        List<Booking> ?bookings { get; set;}
    }
}
