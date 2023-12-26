using BuildingBlocks.EFCore;
using BuildingBlocks.IdsGenerator;
using Customers.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customers;

public static class CustomerModule
{
    public static IServiceCollection AddCustomerModules(this IServiceCollection services, IConfiguration configuration)
    {
        SnowFlakIdGenerator.Configure(1);

        services.AddCustomDbContext<CustomerDbContext>(nameof(Customers), configuration);

        return services;
    }

}
