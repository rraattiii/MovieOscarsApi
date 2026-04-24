using Microsoft.EntityFrameworkCore;
using MovieOscarsApi.Models;

namespace MovieOscarsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(movie => movie.Title)
            .HasMaxLength(150);

        modelBuilder.Entity<Movie>()
            .Property(movie => movie.Director)
            .HasMaxLength(100);

        modelBuilder.Entity<Movie>()
            .Property(movie => movie.Genre)
            .HasMaxLength(50);
    }
}
