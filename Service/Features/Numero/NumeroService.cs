using ApiPaliNumb.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaliNumb.Service.Features.Numero
{
    public class NumeroService : INumeroService
    {
        private readonly INumeroRepository _repo;
        public NumeroService(INumeroRepository repo)
        {
            _repo = repo;
        }

        public bool EsPar(int numero)
        {
            return numero % 2 == 0;
        }

        public async Task<IEnumerable<Infrastructure.Numero>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Infrastructure.Numero?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Infrastructure.Numero?> GetByValorAsync(int valor) => await _repo.GetByValorAsync(valor);
        public async Task AddAsync(Infrastructure.Numero numero) => await _repo.AddAsync(numero);
        public async Task UpdateAsync(Infrastructure.Numero numero) => await _repo.UpdateAsync(numero);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}