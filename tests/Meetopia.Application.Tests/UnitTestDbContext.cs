using Meetopia.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Meetopia.Application.Tests;

public static class UnitTestDbContext
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }
}