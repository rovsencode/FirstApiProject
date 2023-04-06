using Microsoft.EntityFrameworkCore;
using P326FirstWebAPI.Models;

namespace P326FirstWebAPI.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
