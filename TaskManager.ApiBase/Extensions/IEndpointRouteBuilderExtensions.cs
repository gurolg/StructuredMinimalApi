using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.ApiBase.Extensions;

public static class IEndpointRouteBuilderExtensions
{
    public static void MapTaskManagerEndpoints(this Microsoft.AspNetCore.Builder.WebApplication builder)
    {
        var scope = builder.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IYaverEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.AddRoute(builder);
        }
    }
}
