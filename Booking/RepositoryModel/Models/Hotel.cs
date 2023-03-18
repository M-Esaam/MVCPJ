using RepositoryModel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public enum Hotel_Rate_Star:int
    {
        Star=1,
        TwoStars,
        ThreeSars,
        FourStars,
        FiveStars,
        SixStars,
        SevenStars
    }


    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Hotel_Rate_Star Rate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }

        [ForeignKey("Hotel_Manager")]
        public string? Hotel_ManagerId { get; set; }
        public Hotel_Manager? Hotel_Manager { get; set; }
        public List<image>? Images { get; set; }
        public List<Room>? rooms { get; set; }
        public List<Review>? reviews { get; set; }
        public bool IsConfermed { get; set; }
        public bool IsDeleted { get; set; }

    }
}