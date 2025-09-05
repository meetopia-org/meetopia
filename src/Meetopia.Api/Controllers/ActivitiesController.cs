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
}