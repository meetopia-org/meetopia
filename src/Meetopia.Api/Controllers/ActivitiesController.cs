using Meetopia.Application.Activities.Commands;
using Meetopia.Application.Activities.Queries;
using Meetopia.Domain.Activities.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Meetopia.Api.Controllers;

public class ActivitiesController
    : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivities(CancellationToken cancellationToken)
    {
        var activities = await Mediator.Send(new GetActivityListQuery(), cancellationToken);
        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id, CancellationToken cancellationToken)
    {
        var activity = await Mediator.Send(new GetActivityDetailsQuery { Id = id }, cancellationToken);
        return Ok(activity);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        var id = await Mediator.Send(new CreateActivityCommand() { Activity = activity });
        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivityCommand { Activity = activity });
        return NoContent();
    }
}