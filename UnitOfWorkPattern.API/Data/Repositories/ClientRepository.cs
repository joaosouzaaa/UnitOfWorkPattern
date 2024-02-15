using UnitOfWorkPattern.API.Data.DatabaseContexts;
using UnitOfWorkPattern.API.Data.Repositories.BaseRepositories;
using UnitOfWorkPattern.API.Entities;
using UnitOfWorkPattern.API.Interfaces.Repositories;

namespace UnitOfWorkPattern.API.Data.Repositories;

public sealed class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(UnitOfWorkPatternDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddAsync(Client client)
    {
        await DbContextSet.AddAsync(client);

        await _dbContext.SaveChangesAsync();
    }
}
