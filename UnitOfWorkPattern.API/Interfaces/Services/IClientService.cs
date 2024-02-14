using UnitOfWorkPattern.API.DataTransferObjects.Client;

namespace UnitOfWorkPattern.API.Interfaces.Services;

public interface IClientService
{
    Task AddAsync(ClientSave clientSave);
}
