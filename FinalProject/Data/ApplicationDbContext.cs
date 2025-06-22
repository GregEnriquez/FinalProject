using FinalProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{

    // Represents database context and inherits from DbContext
    public class ApplicationDbContext : DbContext
    {

        // Constructor that receives options (like the connection string) from the startup configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        // Represents the Inventory table in database
        public DbSet<Inventory> Inventory { get; set; }

        // Represents the User table in database
        public DbSet<User> Users { get; set; }

    }
}
