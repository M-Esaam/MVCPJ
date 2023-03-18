using BookingLibrary.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using System.ComponentModel.DataAnnotations;

namespace Booking.ViewModel
{
    public class PartnerRegaestrationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HotelStreet { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        

        [Required]
        public string HotelName { get; set; }

        [Required]
        public string HotelDescription { get; set; }

        
        public image? Image { get; set; }

        [Required]
        public string HotelRate { get; set; }
    }
}
