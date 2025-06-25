using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class NumeroCreateDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Valor { get; set; }
    }
}
