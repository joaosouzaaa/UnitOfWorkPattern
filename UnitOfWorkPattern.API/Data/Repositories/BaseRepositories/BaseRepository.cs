using Microsoft.EntityFrameworkCore;
using UnitOfWorkPattern.API.Data.DatabaseContexts;

namespace UnitOfWorkPattern.API.Data.Repositories.BaseRepositories;

public abstract class BaseRepository<TEntity>(UnitOfWorkPatternDbContext dbContext) : IDisposable
    where TEntity : class
{
    protected DbSet<TEntity> DbContextSet => dbContext.Set<TEntity>();

    public void Dispose()
    {
        dbContext.Dispose();

        GC.SuppressFinalize(this);
    }
}
