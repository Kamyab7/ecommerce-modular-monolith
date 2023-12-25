using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace BuildingBlocks.MediatR;

public static class Extensions
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(assemblies);

        return services;
    }
}
