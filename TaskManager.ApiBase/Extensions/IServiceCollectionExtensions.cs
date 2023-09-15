using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.ApiBase.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddTaskManagerEndpoints(this IServiceCollection services)
    {
        var endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(IYaverEndpoint)))
            .Where(t => !t.IsInterface && !t.IsAbstract);

        foreach (var endpoint in endpoints)
        {
            services.AddScoped(typeof(IYaverEndpoint), endpoint);
        }

        return services;
    }
}
