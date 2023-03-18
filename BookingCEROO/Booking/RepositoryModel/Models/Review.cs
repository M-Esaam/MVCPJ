using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public class Review
    {
        public int Id { get; set; }
        //new
        public string Text { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel ?Hotel { get; set; }
       
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer ?Customer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
