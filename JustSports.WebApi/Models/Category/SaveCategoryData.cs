using System.ComponentModel.DataAnnotations;

namespace JustSports.WebApi.Models
{
    public class SaveCategoryData
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
    }
}
