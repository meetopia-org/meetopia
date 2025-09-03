using Meetopia.Application.Common.Interfaces;
using Meetopia.Domain.Activities.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meetopia.Api.Controllers;

public class ActivitiesController(
    IApplicationDbContext dbContext)
    : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivities(CancellationToken cancellationToken)
    {
        var activities = await dbContext.Activities.ToListAsync(cancellationToken);
        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id, CancellationToken cancellationToken)
    {
        var activity = await dbContext.Activities.FindAsync([id], cancellationToken);

        return activity == null
            ? NoContent()
            : Ok(activity);
    }
}