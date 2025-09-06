using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Activities.Commands;

public class DeleteActivityCommand : IRequest
{
    public required string Id { get; set; }
}

public class DeleteActivityCommandHandler(
    IApplicationDbContext dbContext)
    : IRequestHandler<DeleteActivityCommand>
{
    public async Task Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        Activity activity = await dbContext.Activities.FindAsync([request.Id], cancellationToken)
            ?? throw new InvalidOperationException("Activity not found");

        dbContext.Activities.Remove(activity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}