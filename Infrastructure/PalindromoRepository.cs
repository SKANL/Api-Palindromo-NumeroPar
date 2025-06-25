using ApiPaliNumb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaliNumb.Infrastructure
{
    public class PalindromoRepository : IPalindromoRepository
    {
        private readonly AppDbContext _context;
        public PalindromoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Palindromo>> GetAllAsync() => await _context.Palindromos.ToListAsync();
        public async Task<Palindromo?> GetAsync(int id) => await _context.Palindromos.FindAsync(id);
        public async Task AddAsync(Palindromo palindromo)
        {
            _context.Palindromos.Add(palindromo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Palindromo palindromo)
        {
            _context.Palindromos.Update(palindromo);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Palindromos.FindAsync(id);
            if (entity != null)
            {
                _context.Palindromos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id) => await _context.Palindromos.AnyAsync(p => p.Id == id);
    }
}
