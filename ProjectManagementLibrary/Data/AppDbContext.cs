using Microsoft.EntityFrameworkCore;
using ProjectManagementLibrary.Models;

namespace ProjectManagementLibrary.Data;



// En del kod ifrån chatgpt, behövde rätt konstruktor för DI som kör i runtime annars krashar programmet

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Customer> Customers { get; set; }

   
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

   
    public AppDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=projects.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .Property(p => p.TotalPrice)
            .HasColumnType("REAL"); 
    }
}
