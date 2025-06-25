using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class PalindromoCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Texto { get; set; } = string.Empty;
    }
}
