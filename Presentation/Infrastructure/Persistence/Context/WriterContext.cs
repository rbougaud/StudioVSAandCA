using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class WriterContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public WriterContext(DbContextOptions<WriterContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }
}
