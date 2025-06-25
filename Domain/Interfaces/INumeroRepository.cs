using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaliNumb.Domain.Interfaces
{
    public interface INumeroRepository
    {
        Task<IEnumerable<Infrastructure.Numero>> GetAllAsync();
        Task<Infrastructure.Numero?> GetByIdAsync(int id);
        Task<Infrastructure.Numero?> GetByValorAsync(int valor);
        Task AddAsync(Infrastructure.Numero numero);
        Task UpdateAsync(Infrastructure.Numero numero);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
