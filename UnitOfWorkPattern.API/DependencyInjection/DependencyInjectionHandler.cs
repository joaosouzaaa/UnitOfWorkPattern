using Microsoft.EntityFrameworkCore;
using UnitOfWorkPattern.API.Data.DatabaseContexts;
using UnitOfWorkPattern.API.Factories;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<UnitOfWorkPatternDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString();
            options.UseSqlServer(connectionString);
        });

        services.AddSettingsDependencyInjection();
        services.AddFiltersDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
