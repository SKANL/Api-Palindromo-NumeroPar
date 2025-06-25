using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class PalindromoDto
    {
        public int? Id { get; set; } // Solo de salida (GET), no se envía en POST
        [Required]
        public string Texto { get; set; } = string.Empty;
        public bool EsPalindromo { get; set; }
    }
}
