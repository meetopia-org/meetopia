using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Activities.Queries;

public class GetActivityDetailsQuery : IRequest<Activity>
{
    public required string Id { get; set; }
}

public class GetActivityDetailsHandler(
    IApplicationDbContext dbContext)
    : IRequestHandler<GetActivityDetailsQuery, Activity>
{
    public async Task<Activity> Handle(GetActivityDetailsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var activity = await dbContext.Activities.FindAsync([request.Id], cancellationToken)
            ?? throw new KeyNotFoundException($"Activity with ID '{request.Id}' was not found.");

        return activity;
    }
}