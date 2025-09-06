using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Meetopia.Api.Tests.Setup;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Api.Tests.Endpoints;

public class ActivityEnpointsTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    private const string Route = "api/activities";
    private readonly Uri _baseUri = new(Route, UriKind.Relative);

    [Fact]
    public async Task Get_ShouldReturnOk()
    {
        // Act
        var response = await HttpClient.GetAsync(_baseUri);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_ShouldReturnOk()
    {
        // Arrange
        var activity = CreateActivity();

        // Act
        var response = await HttpClient.PostAsJsonAsync(new Uri("api/activities", UriKind.Relative), activity);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Put_ShouldReturnNoContent()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var activity = CreateActivity(id);
        DbContext.Activities.Add(activity);
        await DbContext.SaveChangesAsync();

        var activityEdited = CreateActivity(id);
        activityEdited.Title = "New Title";

        var response = await HttpClient.PutAsJsonAsync(_baseUri, activityEdited);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    private static Activity CreateActivity(string? id = null)
    {
        var activity = new Activity
        {
            Title = "Test activity",
            Date = new DateTime(2025, 9, 6, 17, 26, 14, DateTimeKind.Utc),
            Description = "Test description",
            Category = "Test category",
            City = "Test city",
            Venue = "Test venue",
            Latitude = 0,
            Longitude = 0
        };

        if (id is not null)
        {
            activity.Id = id;
        }

        return activity;
    }
}