using RepositoryModel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Room_Num { get; set; }
        public int NumOfAdults { get; set; }
        public double Cost_Per_Night { get; set; }

        public bool ISavailable { get; set; }
       
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel ?Hotel { get; set; }
        [ForeignKey("Suit")]
        public int SuitId { get; set; }
        public Suit Suit { get; set; }
        [ForeignKey("Normal_Room")]
        public int Normal_NumberId { get; set; }
        public Normal_Room ?Normal_Room { get; set; }
        public bool IsDeleted { get; set; }

    }
}