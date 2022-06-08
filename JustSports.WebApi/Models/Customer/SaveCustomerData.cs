using System.ComponentModel.DataAnnotations;

namespace JustSports.WebApi.Models
{
    public class SaveCustomerData
    {
        [StringLength(250)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
        
    }
}
