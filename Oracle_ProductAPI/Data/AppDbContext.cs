using Microsoft.EntityFrameworkCore;
using Oracle_ProductAPI.Models;

namespace Oracle_ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> TBD_Produtos { get; set; }

    }
}
