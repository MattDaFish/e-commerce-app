using System.ComponentModel.DataAnnotations;

namespace JustSports.WebApi.Models
{
    public class AuthenticateAccount
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address specified")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
