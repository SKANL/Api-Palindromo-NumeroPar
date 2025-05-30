using ApiPaliNumb.Domain.Entities;
using ApiPaliNumb.Domain.Interfaces;

namespace ApiPaliNumb.Service.Features.Palindromo
{
    public class PalindromoService : IPalindromoService
    {
        public bool EsPalindromo(string palabra)
        {
            string palabraLimpia = new string(palabra.ToLower().Where(char.IsLetter).ToArray());
            return palabraLimpia == new string(palabraLimpia.Reverse().ToArray());
        }
    }
}