using Meetopia.Domain.Activities.Entities;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Activity> Activities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}