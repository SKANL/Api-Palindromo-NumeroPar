using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaliNumb.Infrastructure
{
    public class Numero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Valor { get; set; }
        public bool EsPar { get; set; }
    }
}
