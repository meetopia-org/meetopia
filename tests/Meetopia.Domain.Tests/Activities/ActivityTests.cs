using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Domain.Tests.Activities;

public class ActivityTests
{
    [Fact]
    public void Activity_Creation_Sets_Id()
    {
        var activity = new Activity
        {
            Title = "Sample Title",
            Description = "Sample Description",
            Category = "Sample Category",
            City = "Sample City",
            Venue = "Sample Venue"
        };

        var id = activity.Id;

        id.ShouldNotBeNullOrEmpty();
    }
}