using System.ComponentModel.DataAnnotations;

namespace BookingWebSite.ViewModel
{
    public class LoginViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
