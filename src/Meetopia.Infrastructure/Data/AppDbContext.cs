using Meetopia.Domain.Activities.Entities;
using Meetopia.Infrastructure.Data.Seed;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Activity>(e => e.HasData(ActivitySeed.Activities));
    }
}