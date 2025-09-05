using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Meetopia.Application;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(
                typeof(DependencyInjectionExtensions).Assembly));

        return builder;
    }
}
