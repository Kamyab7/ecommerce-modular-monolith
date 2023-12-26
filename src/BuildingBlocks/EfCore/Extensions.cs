using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.EFCore;

public static class Extensions
{
    public static IServiceCollection AddCustomDbContext<TContext>(
        this IServiceCollection services,
        string connectionName,
        IConfiguration configuration)
        where TContext : DbContext, IDbContext
    {

        services.AddDbContext<TContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString(connectionName),
                dbOptions =>
                {
                    dbOptions.MigrationsAssembly(typeof(TContext).Assembly.GetName().Name);
                    //ref: https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                    dbOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(1), null);
                });

            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });


        services.AddScoped<IDbContext>(provider => provider.GetService<TContext>());

        return services;
    }


    public static IApplicationBuilder UseMigration<TContext>(this IApplicationBuilder app)
        where TContext : DbContext, IDbContext
    {
        MigrateDatabaseAsync<TContext>(app.ApplicationServices).GetAwaiter().GetResult();
        SeedDataAsync<TContext>(app.ApplicationServices).GetAwaiter().GetResult();

        return app;
    }

    private static async Task MigrateDatabaseAsync<TContext>(IServiceProvider serviceProvider)
        where TContext : DbContext, IDbContext
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        await context.Database.MigrateAsync();
    }

    private static async Task SeedDataAsync<TContext>(IServiceProvider serviceProvider)
        where TContext : DbContext, IDbContext
    {
        //using var scope = serviceProvider.CreateScope();
        //var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();
        //foreach (var seeder in seeders)
        //{
        //    await seeder.SeedAllAsync<TContext>();
        //}
    }

}
