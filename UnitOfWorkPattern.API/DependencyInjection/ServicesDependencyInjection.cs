using UnitOfWorkPattern.API.Interfaces.Services;
using UnitOfWorkPattern.API.Services;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
    }
}
