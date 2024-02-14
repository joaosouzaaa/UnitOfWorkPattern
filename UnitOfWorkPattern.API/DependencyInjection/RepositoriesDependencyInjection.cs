using UnitOfWorkPattern.API.Data.Repositories;
using UnitOfWorkPattern.API.Interfaces.Repositories;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
    }
}
