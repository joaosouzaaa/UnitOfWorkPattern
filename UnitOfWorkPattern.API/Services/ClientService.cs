using UnitOfWorkPattern.API.DataTransferObjects.Client;
using UnitOfWorkPattern.API.Entities;
using UnitOfWorkPattern.API.Interfaces.Repositories;
using UnitOfWorkPattern.API.Interfaces.Services;
using UnitOfWorkPattern.API.Interfaces.Settings;

namespace UnitOfWorkPattern.API.Services;

public sealed class ClientService(IClientRepository clientRepository, ILogRepository logRepository,
                                  INotificationHandler notificationHandler) : IClientService
{
    public async Task AddAsync(ClientSave clientSave)
    {
        var client = SaveToDomain(clientSave);

        if (!IsClientValid(client))
        {
            notificationHandler.AddNotification("Invalid", "The Client is invalid");

            return;
        }

        await clientRepository.AddAsync(client);

        var log = new Log()
        {
            CreationDate = DateTime.Now,
            Message = "A client has been added"
        };

        await logRepository.AddAsync(log);
    }

    private static Client SaveToDomain(ClientSave clientSave) =>
        new()
        {
            Age = clientSave.Age,
            Balance = clientSave.Balance,
            Name = clientSave.Name
        };

    private static bool IsClientValid(Client client) =>
        client.Age > 0 
        && client.Name.Length > 1 
        && client.Name.Length < 100;
}
