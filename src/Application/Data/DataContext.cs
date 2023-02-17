using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>()
            .Property(p => p.UserName)
            .HasColumnType("varchar(100)");
    }

    public DbSet<Login> Logins { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
}
