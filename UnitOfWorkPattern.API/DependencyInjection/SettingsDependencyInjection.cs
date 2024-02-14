using UnitOfWorkPattern.API.Interfaces.Settings;
using UnitOfWorkPattern.API.Settings.NotificationSettings;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
