using ApiPaliNumb.Domain.Entities;
using ApiPaliNumb.Domain.Interfaces;

namespace ApiPaliNumb.Service.Features.Numero
{
    public class NumeroService : INumeroService
    {
        public bool EsPar(int numero)
        {
            return numero % 2 == 0;
        }
    }
}