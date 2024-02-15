using Microsoft.EntityFrameworkCore;
using UnitOfWorkPattern.API.Data.DatabaseContexts;

namespace UnitOfWorkPattern.API.Settings.MigrationSettings;

public static class MigrationHandler
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<UnitOfWorkPatternDbContext>();

        try
        {
            dbContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
