using Microsoft.EntityFrameworkCore.Infrastructure;
using UnitOfWorkPattern.API.Data.DatabaseContexts;
using UnitOfWorkPattern.API.Interfaces.UnitOfWork;

namespace UnitOfWorkPattern.API.Data.UnitOfWork;

public sealed class UnitOfWork(UnitOfWorkPatternDbContext dbContext) : IUnitOfWork
{
    private readonly DatabaseFacade _dbFacade = dbContext.Database;

    public void BeginTransaction() =>
        _dbFacade.BeginTransaction();

    public void CommitTransaction()
    {
        try
        {
            _dbFacade.CommitTransaction();
        }
        catch
        {
            RollbackTransaction();

            throw;
        }
    }

    public void RollbackTransaction() =>
        _dbFacade.RollbackTransaction();
}
