using Meetopia.Application.Activities.Commands;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Application.Tests.Activities;

public class DeleteActivityTests
{
    [Fact]
    public async Task DeleteActivityCommand_ShouldDeleteActivity()
    {
        // Arrange
        using var dbContext = UnitTestDbContext.Create();

        var activity = CreateActivity();
        dbContext.Activities.Add(activity);
        await dbContext.SaveChangesAsync();

        var command = new DeleteActivityCommand { Id = activity.Id };
        var deleteActivityHandler = new DeleteActivityCommandHandler(dbContext);

        // Act
        await deleteActivityHandler.Handle(command, CancellationToken.None);

        // Assert
        var deletedActivity = await dbContext.Activities.FindAsync(activity.Id);
        deletedActivity.ShouldBeNull();
    }

    private static Activity CreateActivity()
    {
        return new Activity
        {
            Id = "activity-to-delete-1",
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