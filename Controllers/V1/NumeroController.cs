using ApiPaliNumb.Domain.Entities;
using ApiPaliNumb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaliNumb.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NumeroController : ControllerBase
    {
        private readonly INumeroService _servicioNumero;

        public NumeroController(INumeroService servicioNumero)
        {
            _servicioNumero = servicioNumero;
        }

        [HttpGet("{numero}")]
        public IActionResult VerificarPar(int numero)
        {
            bool esPar = _servicioNumero.EsPar(numero);
            return Ok(new Numero { Valor = numero, EsPar = esPar });
        }
    }
}