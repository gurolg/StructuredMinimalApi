using Microsoft.Extensions.DependencyInjection;

namespace ProductManager.ApiBase.Extensions;

public static class IEndpointRouteBuilderExtensions
{
    public static void MapProductManagerEndpoints(this Microsoft.AspNetCore.Builder.WebApplication builder)
    {
        var scope = builder.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IYaverEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.AddRoute(builder);
        }
    }
}
