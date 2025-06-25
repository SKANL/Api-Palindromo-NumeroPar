using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaliNumb.Infrastructure
{
    public class Palindromo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public bool EsPalindromo { get; set; }
    }
}
