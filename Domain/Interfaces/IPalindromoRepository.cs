using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaliNumb.Domain.Interfaces
{
    public interface IPalindromoRepository
    {
        Task<IEnumerable<Infrastructure.Palindromo>> GetAllAsync();
        Task<Infrastructure.Palindromo?> GetAsync(int id);
        Task AddAsync(Infrastructure.Palindromo palindromo);
        Task UpdateAsync(Infrastructure.Palindromo palindromo);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
