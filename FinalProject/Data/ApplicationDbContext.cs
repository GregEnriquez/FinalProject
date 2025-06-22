using FinalProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
