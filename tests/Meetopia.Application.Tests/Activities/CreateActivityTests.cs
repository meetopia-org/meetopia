using Meetopia.Application.Activities.Commands;
using Meetopia.Domain.Activities.Entities;
using Meetopia.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Application.Tests.Activities;

public class CreateActivityTests
{

    [Fact]
    public async Task Handle_GivenValidActivity_CreatesActivity()
    {
        // Arrange
        using var dbContext = CreateDbContext();

        var activity = new Activity()
        {
            Id = "123",
            Title = "Title",
            Category = "Category",
            Description = "Descripction",
            City = "City",
            Venue = "Venue"
        };

        var command = new CreateActivityCommand() { Activity = activity };
        var createActivityHandler = new CreateActivityCommandHandler(dbContext);

        // Act
        string id = await createActivityHandler.Handle(command, CancellationToken.None);

        // Assert
        id.ShouldBe(activity.Id);
        var createdEntity = await dbContext.Activities.FirstOrDefaultAsync(a => a.Id == activity.Id);
        createdEntity.ShouldNotBeNull();
    }

    private static AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }
}