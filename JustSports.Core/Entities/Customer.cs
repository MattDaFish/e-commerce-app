using System.ComponentModel.DataAnnotations;

namespace JustSports.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        [StringLength(60)]
        public string Surname { get; set; } = string.Empty;

        [StringLength(15)]
        public string CellNumber { get; set; } = string.Empty;

        [StringLength(250)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        public bool IsEmailVerified { get; set; }

    }
}
