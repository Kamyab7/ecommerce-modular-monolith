using BuildingBlocks.IdsGenerator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customers;

public static class CustomerModule
{
    public static IServiceCollection AddCustomerModules(this IServiceCollection services, IConfiguration configuration)
    {
        SnowFlakIdGenerator.Configure(1);

        return services;
    }

}
