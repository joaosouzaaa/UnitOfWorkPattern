using UnitOfWorkPattern.API.Settings.NotificationSettings;

namespace UnitOfWorkPattern.API.Interfaces.Settings;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
}
