using MemoryGameDotNetBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGameDotNetBackend
{
    public class MemoryGameContext : DbContext
    {
        public MemoryGameContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3308;user=username;password=password;database=android_db;",
                new MySqlServerVersion(new Version(8, 0, 41))
            );

            optionsBuilder.UseLazyLoadingProxies();
        }

        // db tables
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Game { get; set; }
    }
}
