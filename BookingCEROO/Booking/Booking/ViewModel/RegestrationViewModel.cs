using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace BookingWebSite.ViewModel
{
    public class RegestrationViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }


        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Option]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
