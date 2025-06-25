using System.Threading.Tasks;
using ApiPaliNumb.Infrastructure;

namespace ApiPaliNumb.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task<bool> ExistsAsync(string username);
    }
}
