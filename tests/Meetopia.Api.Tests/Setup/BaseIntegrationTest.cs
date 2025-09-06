using MediatR;

using Meetopia.Infrastructure.Data;

using Microsoft.Extensions.DependencyInjection;

namespace Meetopia.Api.Tests.Setup;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    protected HttpClient HttpClient { get; }

    protected AppDbContext DbContext { get; }

    private readonly IServiceScope _scope;

    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        ArgumentNullException.ThrowIfNull(factory);

        _scope = factory.Services.CreateScope();
        HttpClient = factory.CreateClient();
        DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }
}