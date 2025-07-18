namespace ApiPaliNumb.Domain.Interfaces
{
    public interface INumeroService
    {
        bool EsPar(int numero);
        // CRUD
        Task<IEnumerable<Infrastructure.Numero>> GetAllAsync();
        Task<Infrastructure.Numero?> GetByIdAsync(int id);
        Task<Infrastructure.Numero?> GetByValorAsync(int valor);
        Task AddAsync(Infrastructure.Numero numero);
        Task UpdateAsync(Infrastructure.Numero numero);
        Task DeleteAsync(int id);
    }
}