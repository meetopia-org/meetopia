namespace Meetopia.Api;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationCors(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

        return app.UseCors(opt => opt
            .AllowAnyHeader()
            .AllowAnyMethod().WithOrigins(config?.GetSection("Cors:Origins")?.Get<string[]>() ?? []));
    }
}