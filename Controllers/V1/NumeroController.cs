using ApiPaliNumb.Domain.Interfaces;
using ApiPaliNumb.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;

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
            return Ok(new NumeroDto { Id = null, EsPar = esPar });
        }

        // CRUD
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _servicioNumero.GetAllAsync();
            return Ok(result.Select(n => new NumeroDto { Id = n.Id, EsPar = n.EsPar }));
        }

        // GET paginado y filtrado
        [Authorize]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int? valor = null)
        {
            var result = await _servicioNumero.GetAllAsync();
            if (valor.HasValue)
                result = result.Where(n => n.Valor == valor.Value).ToList();
            var total = result.Count();
            var items = result.Skip((page - 1) * pageSize).Take(pageSize)
                .Select(n => new NumeroDto { Id = n.Id, EsPar = n.EsPar }).ToList();
            return Ok(new { success = true, total, page, pageSize, data = items });
        }

        [Authorize]
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var numero = await _servicioNumero.GetByIdAsync(id);
            if (numero == null) return NotFound();
            return Ok(new NumeroDto { Id = numero.Id, EsPar = numero.EsPar });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NumeroCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, errors = ModelState });
            var entity = new Infrastructure.Numero { Valor = dto.Valor, EsPar = dto.Valor % 2 == 0 };
            await _servicioNumero.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, new { success = true, data = new NumeroDto { Id = entity.Id, EsPar = entity.EsPar } });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NumeroUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, errors = ModelState });
            if (await _servicioNumero.GetByIdAsync(dto.Id) == null) return NotFound();
            var entity = new Infrastructure.Numero { Id = dto.Id, Valor = dto.Valor, EsPar = dto.Valor % 2 == 0 };
            await _servicioNumero.UpdateAsync(entity);
            return Ok(new { success = true });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _servicioNumero.GetByIdAsync(id) == null) return NotFound();
            await _servicioNumero.DeleteAsync(id);
            return Ok(new { success = true });
        }
    }
}