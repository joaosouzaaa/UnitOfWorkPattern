using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkPattern.API.Data.DatabaseContexts;

public sealed class UnitOfWorkPatternDbContext(DbContextOptions<UnitOfWorkPatternDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnitOfWorkPatternDbContext).Assembly);
    }
}
