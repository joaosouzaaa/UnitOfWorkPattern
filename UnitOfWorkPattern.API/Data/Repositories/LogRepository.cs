using UnitOfWorkPattern.API.Data.DatabaseContexts;
using UnitOfWorkPattern.API.Data.Repositories.BaseRepositories;
using UnitOfWorkPattern.API.Entities;
using UnitOfWorkPattern.API.Interfaces.Repositories;

namespace UnitOfWorkPattern.API.Data.Repositories;

public sealed class LogRepository : BaseRepository<Log>, ILogRepository
{
    public LogRepository(UnitOfWorkPatternDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddAsync(Log log) =>
        await DbContextSet.AddAsync(log);
}
