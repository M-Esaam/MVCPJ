using Microsoft.AspNetCore.Identity;
using RepositoryModel.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingLibrary.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class AppUser:IdentityUser
    {
        public string? NID { get; set; }
        public Gender? gender { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }

        [ForeignKey("image")]
        public int? ImageId { get; set; }
        public image? image { get; set; }

        public bool IsDeleted { get; set; }

    }
}
