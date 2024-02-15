namespace UnitOfWorkPattern.API.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
