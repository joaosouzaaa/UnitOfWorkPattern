﻿using Microsoft.EntityFrameworkCore;
using UnitOfWorkPattern.API.Data.DatabaseContexts;

namespace UnitOfWorkPattern.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<UnitOfWorkPatternDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddRepositoriesDependencyInjection();
    }
}
