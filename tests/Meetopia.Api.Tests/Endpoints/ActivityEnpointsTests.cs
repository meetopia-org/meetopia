using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Meetopia.Api.Tests.Setup;
using Meetopia.Domain.Activities.Entities;

namespace Meetopia.Api.Tests.Endpoints;

public class ActivityEnpointsTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Get_ShouldReturnOk()
    {
        // Act
        var response = await HttpClient.GetAsync(new Uri("api/activities", UriKind.Relative));

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_ShouldReturnOk()
    {
        // Arrange
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

        // Act
        var response = await HttpClient.PostAsJsonAsync(new Uri("api/activities", UriKind.Relative), activity);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}