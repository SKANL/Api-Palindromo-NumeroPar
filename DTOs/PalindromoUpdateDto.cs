using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class PalindromoUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Texto { get; set; } = string.Empty;
    }
}
