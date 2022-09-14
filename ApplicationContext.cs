using Microsoft.EntityFrameworkCore;
using ModernUI.Models;

namespace ModernUI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ModernUIUserDb;Username=postgres;Password=AKChess16022007_N");
        }
    }
}