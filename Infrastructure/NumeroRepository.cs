using ApiPaliNumb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiPaliNumb.Infrastructure
{
    public class NumeroRepository : INumeroRepository
    {
        private readonly AppDbContext _context;
        public NumeroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Numero>> GetAllAsync() => await _context.Numeros.ToListAsync();
        public async Task<Numero?> GetByIdAsync(int id) => await _context.Numeros.FindAsync(id);
        public async Task<Numero?> GetByValorAsync(int valor) => await _context.Numeros.FirstOrDefaultAsync(n => n.Valor == valor);
        public async Task AddAsync(Numero numero)
        {
            _context.Numeros.Add(numero);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Numero numero)
        {
            _context.Numeros.Update(numero);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Numeros.FindAsync(id);
            if (entity != null)
            {
                _context.Numeros.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id) => await _context.Numeros.AnyAsync(n => n.Id == id);
    }
}
