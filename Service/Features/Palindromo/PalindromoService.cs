using ApiPaliNumb.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPaliNumb.Service.Features.Palindromo
{
    public class PalindromoService : IPalindromoService
    {
        private readonly IPalindromoRepository _repo;
        public PalindromoService(IPalindromoRepository repo)
        {
            _repo = repo;
        }

        public bool EsPalindromo(string palabra)
        {
            string palabraLimpia = new string(palabra.ToLower().Where(char.IsLetter).ToArray());
            return palabraLimpia == new string(palabraLimpia.Reverse().ToArray());
        }

        public async Task<IEnumerable<Infrastructure.Palindromo>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Infrastructure.Palindromo?> GetAsync(int id) => await _repo.GetAsync(id);
        public async Task AddAsync(Infrastructure.Palindromo palindromo) => await _repo.AddAsync(palindromo);
        public async Task UpdateAsync(Infrastructure.Palindromo palindromo) => await _repo.UpdateAsync(palindromo);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}