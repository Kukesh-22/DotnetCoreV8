using System.ComponentModel.DataAnnotations;

namespace Dotnet_v8.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(4,ErrorMessage ="Code must be greater two character.")]
        [MaxLength(4,ErrorMessage ="code must be less than four character.")]
        public string? Code { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
