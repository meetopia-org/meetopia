using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Activities.Commands;

public class EditActivityCommand : IRequest
{
    public required Activity Activity { get; set; }
}

public class EditActivityCommandHandler(
    IApplicationDbContext dbContext)
    : IRequestHandler<EditActivityCommand>
{
    public async Task Handle(EditActivityCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        Activity activity = await dbContext.Activities.FindAsync([request.Activity.Id], cancellationToken)
            ?? throw new InvalidOperationException("Activity not found");

        activity.UpdateFrom(request.Activity);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}