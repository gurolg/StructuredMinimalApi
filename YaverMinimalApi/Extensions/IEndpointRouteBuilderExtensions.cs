namespace YaverMinimalApi.Extensions;

public static class IEndpointRouteBuilderExtensions
{
    public static void MapEndpoints(this WebApplication builder)
    {
        var scope = builder.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IYaverEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.AddRoute(builder);
        }
    }
}
