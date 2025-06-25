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
            return Ok(new PalindromoDto { Texto = palabra, EsPalindromo = esPalindromo });
        }

        // CRUD
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _servicioPalindromo.GetAllAsync();
            return Ok(result.Select(p => new PalindromoDto { Id = p.Id, Texto = p.Texto, EsPalindromo = p.EsPalindromo }));
        }

        // GET paginado y filtrado
        [Authorize]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? texto = null)
        {
            var result = await _servicioPalindromo.GetAllAsync();
            if (!string.IsNullOrEmpty(texto))
                result = result.Where(p => p.Texto.Contains(texto)).ToList();
            var total = result.Count();
            var items = result.Skip((page - 1) * pageSize).Take(pageSize)
                .Select(p => new PalindromoDto { Id = p.Id, Texto = p.Texto, EsPalindromo = p.EsPalindromo }).ToList();
            return Ok(new { success = true, total, page, pageSize, data = items });
        }

        [Authorize]
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var palindromo = await _servicioPalindromo.GetAsync(id);
            if (palindromo == null) return NotFound();
            return Ok(new PalindromoDto { Id = palindromo.Id, Texto = palindromo.Texto, EsPalindromo = palindromo.EsPalindromo });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PalindromoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, errors = ModelState });
            var esPalindromo = _servicioPalindromo.EsPalindromo(dto.Texto);
            var entity = new Infrastructure.Palindromo { Texto = dto.Texto, EsPalindromo = esPalindromo };
            await _servicioPalindromo.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, new { success = true, data = new PalindromoDto { Id = entity.Id, Texto = entity.Texto, EsPalindromo = entity.EsPalindromo } });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PalindromoUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, errors = ModelState });
            if (await _servicioPalindromo.GetAsync(dto.Id) == null) return NotFound();
            var esPalindromo = _servicioPalindromo.EsPalindromo(dto.Texto);
            var entity = new Infrastructure.Palindromo { Id = dto.Id, Texto = dto.Texto, EsPalindromo = esPalindromo };
            await _servicioPalindromo.UpdateAsync(entity);
            return Ok(new { success = true });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _servicioPalindromo.GetAsync(id) == null) return NotFound();
            await _servicioPalindromo.DeleteAsync(id);
            return Ok(new { success = true });
        }
    }
}