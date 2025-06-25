using System.ComponentModel.DataAnnotations;

namespace ApiPaliNumb.DTOs
{
    public class NumeroDto
    {
        public int? Id { get; set; } // Solo de salida (GET), no se envía en POST

        public bool EsPar { get; set; }
    }
}
