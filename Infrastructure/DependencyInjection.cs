using ApiPaliNumb.Domain.Interfaces;
using ApiPaliNumb.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPaliNumb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ApiPaliNumb.Domain.Interfaces.IUserRepository, UserRepository>();
            services.AddScoped<INumeroRepository, NumeroRepository>();
            services.AddScoped<IPalindromoRepository, PalindromoRepository>();
            return services;
        }
    }
}
