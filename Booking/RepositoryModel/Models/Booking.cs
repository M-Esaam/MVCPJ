using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public class Booking
    {
        
        public int Id { get; set; }
        public double totalPrice { get; set; }


        [ForeignKey ("Customer")]
        public string CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room room { get; set; }

        [CreditCard]
        public string CreditCard_Num { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public bool IsDeleted { get; set; }

    }
}