using LivrosCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosCrud.AppDbContextLivro
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}

