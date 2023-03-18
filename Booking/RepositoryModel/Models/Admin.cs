using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RepositoryModel.Interfaces;

namespace BookingLibrary.Models
{
    public class Admin 
    {
        [Key]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public double TotalProfit { get; set; }
    }
}
