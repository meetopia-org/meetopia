
using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Activities.Commands;

public class CreateActivityCommand : IRequest<string>
{
    public required Activity Activity { get; set; }
}

public class CreateActivityCommandHandler(
    IApplicationDbContext dbContext) : IRequestHandler<CreateActivityCommand, string>
{
    public async Task<string> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        dbContext.Activities.Add(request.Activity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return request.Activity.Id;
    }
}