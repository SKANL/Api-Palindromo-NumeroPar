using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaliNumb.Domain.Interfaces
{
    public interface IPalindromoService
    {
        bool EsPalindromo(string palabra);
        // CRUD
        Task<IEnumerable<Infrastructure.Palindromo>> GetAllAsync();
        Task<Infrastructure.Palindromo?> GetAsync(int id);
        Task AddAsync(Infrastructure.Palindromo palindromo);
        Task UpdateAsync(Infrastructure.Palindromo palindromo);
        Task DeleteAsync(int id);
    }
}