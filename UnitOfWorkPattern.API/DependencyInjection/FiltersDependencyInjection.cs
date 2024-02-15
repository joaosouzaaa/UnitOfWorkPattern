using UnitOfWorkPattern.API.Data.UnitOfWork;
using UnitOfWorkPattern.API.Filters;
using UnitOfWorkPattern.API.Interfaces.UnitOfWork;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class FiltersDependencyInjection
{
    public static void AddFiltersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<NotificationFilter>();
        services.AddMvc(options => options.Filters.AddService<NotificationFilter>());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<UnitOfWorkFilter>();

        services.AddMvc(options => options.Filters.AddService<UnitOfWorkFilter>());
    }
}
