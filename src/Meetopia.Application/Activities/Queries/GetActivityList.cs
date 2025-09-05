
using MediatR;

using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Activities.Queries;

public class GetActivityListQuery : IRequest<List<Activity>>
{
}

public class GetActivityListHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetActivityListQuery, List<Activity>>
{
    public Task<List<Activity>> Handle(GetActivityListQuery request, CancellationToken cancellationToken)
    {
        return dbContext.Activities.ToListAsync(cancellationToken);
    }
}