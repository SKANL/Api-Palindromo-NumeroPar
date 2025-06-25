using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class NumeroUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Valor { get; set; }
    }
}
