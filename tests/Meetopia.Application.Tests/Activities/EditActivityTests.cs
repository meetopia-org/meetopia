using Meetopia.Application.Activities.Commands;
using Meetopia.Domain.Activities.Entities;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Application.Tests.Activities;

public class EditActivityTests
{
    [Fact]
    public async Task EditActivityCommand_ShouldUpdateActivity()
    {
        // Arrange
        using var dbContext = UnitTestDbContext.Create();

        var activity = CreateActivity();
        dbContext.Activities.Add(activity);
        await dbContext.SaveChangesAsync();

        var activityEdited = CreateActivity();
        activityEdited.Title = "New Title";
        activityEdited.Date = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
        activityEdited.Description = "New Description";
        activityEdited.Category = "New Category";
        activityEdited.City = "New City";
        activityEdited.Venue = "New Venue";
        activityEdited.Latitude = 0;
        activityEdited.Longitude = 0;

        var command = new EditActivityCommand { Activity = activityEdited };
        var editActivityHandler = new EditActivityCommandHandler(dbContext);

        // Act
        await editActivityHandler.Handle(command, CancellationToken.None);

        // Assert
        var updatedActivity = await dbContext.Activities.FirstOrDefaultAsync(a => a.Id == activity.Id);
        updatedActivity.ShouldNotBeNull();
        updatedActivity.ShouldBeEquivalentTo(activityEdited);
    }

    private static Activity CreateActivity()
    {
        return new Activity
        {
            Id = "activity-to-edit-1",
            Title = "Past Activity 1",
            Date = new DateTime(2025, 7, 1, 0, 0, 0, DateTimeKind.Utc),
            Description = "Activity 2 months ago",
            Category = "drinks",
            City = "London",
            Venue = "The Lamb and Flag, 33, Rose Street, Seven Dials, Covent Garden, London, Greater London, England, WC2E 9EB, United Kingdom",
            Latitude = 51.51171665,
            Longitude = -0.1256611057818921
        };
    }
}