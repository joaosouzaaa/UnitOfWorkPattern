using UnitOfWorkPattern.API.Entities;

namespace UnitOfWorkPattern.API.Interfaces.Repositories;

public interface ILogRepository
{
    Task AddAsync(Log log);
}
