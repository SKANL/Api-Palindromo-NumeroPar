using ApiPaliNumb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPaliNumb.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Numero> Numeros { get; set; }
        public DbSet<Palindromo> Palindromos { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
