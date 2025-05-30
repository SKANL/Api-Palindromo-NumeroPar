using ApiPaliNumb.Domain.Entities;
using ApiPaliNumb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaliNumb.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PalindromoController : ControllerBase
    {
        private readonly IPalindromoService _servicioPalindromo;

        public PalindromoController(IPalindromoService servicioPalindromo)
        {
            _servicioPalindromo = servicioPalindromo;
        }

        [HttpGet("{palabra}")]
        public IActionResult VerificarPalindromo(string palabra)
        {
            bool esPalindromo = _servicioPalindromo.EsPalindromo(palabra);
            return Ok(new Palindromo { Texto = palabra, EsPalindromo = esPalindromo });
        }
    }
}