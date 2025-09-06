
using Meetopia.Infrastructure.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Testcontainers.PostgreSql;

namespace Meetopia.Api.Tests.Setup;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
#pragma warning disable CA2213 // Disposable fields should be disposed
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
#pragma warning restore CA2213 // Disposable fields should be disposed
        .WithImage("postgres:latest")
        .WithDatabase("meetopia_tests")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ConfigureServices(services =>
        {
            RemoveDbContextServiceRegistration<AppDbContext>(services);
            AddDbContextRegistration<AppDbContext>(services);
        });
    }

    private static void RemoveDbContextServiceRegistration<TDbContext>(IServiceCollection services)
        where TDbContext : DbContext
    {
        var dbContextDescriptor = services.SingleOrDefault(
            d => d.ServiceType == typeof(DbContextOptions<TDbContext>))
            ?? throw new InvalidOperationException($"{nameof(DbContextOptions<TDbContext>)} not found in service collection.");

        services.Remove(dbContextDescriptor);
    }

    private void AddDbContextRegistration<TDbContext>(IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>(options
            => options
                .UseNpgsql(_dbContainer.GetConnectionString() + ";Include Error Detail=true")
                .EnableSensitiveDataLogging());
    }

    public Task InitializeAsync()
    {
        return _dbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.StopAsync();
    }
}