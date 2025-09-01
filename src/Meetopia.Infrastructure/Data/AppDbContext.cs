using Meetopia.Domain.Activities.Entities;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
}