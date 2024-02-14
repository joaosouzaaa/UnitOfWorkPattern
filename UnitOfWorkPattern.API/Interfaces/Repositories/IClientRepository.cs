using UnitOfWorkPattern.API.Entities;

namespace UnitOfWorkPattern.API.Interfaces.Repositories;

public interface IClientRepository
{
    Task AddAsync(Client client);
}
