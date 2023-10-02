#nullable enable

using System.Threading.Tasks;

using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Agrio.PIM.Service.Interceptors;

public class ServerFeaturesInterceptor : Interceptor {
	public override async Task ServerStreamingServerHandler<TRequest, TResponse>(
		TRequest request,
		IServerStreamWriter<TResponse> responseStream,
		ServerCallContext serverCallContext,
		ServerStreamingServerMethod<TRequest, TResponse> continuation
	) {
		SetFeatures(serverCallContext);

		await continuation(request, responseStream, serverCallContext);
	}

	public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
		TRequest request,
		ServerCallContext serverCallContext,
		UnaryServerMethod<TRequest, TResponse> continuation
	) {
		// Get the http context from the server call context
		SetFeatures(serverCallContext);

		// Continue the execution of the pipeline
		return await continuation(request, serverCallContext);
	}

	private static void SetFeatures(ServerCallContext context) {
		var httpContext = context.GetHttpContext();

		// We resolve the client-id header. The RequestHeaders property, will give us the gRPC Metadata
		// https://grpc.io/docs/what-is-grpc/core-concepts/#metadata

		var yTenantIdentifier = context.RequestHeaders.Get("y-tenant-identifier")?.Value;
		var yAcceptLanguage = context.RequestHeaders.Get("y-accept-language")?.Value;
		var yUserId = Guid.Parse(context.RequestHeaders.Get("y-user-id")!.Value);
		var yCorrelationId = context.RequestHeaders.Get("y-correlation-id")!.Value;

		if (string.IsNullOrEmpty(yTenantIdentifier))
			throw new RpcException(new Status(StatusCode.InvalidArgument, "tenant-identifier is mandatory"));

		if (string.IsNullOrEmpty(yAcceptLanguage))
			throw new RpcException(new Status(StatusCode.InvalidArgument, "accept-language is mandatory"));

		if (yUserId == Guid.Empty)
			throw new RpcException(new Status(StatusCode.InvalidArgument, "user-id is mandatory"));


		// https://danielstoyanoff.medium.com/grpc-request-enrichment-dotnet-90ba222c64b1
		// This will make that information available in all gRPC methods

		var tenantContext = new TenantContext(yTenantIdentifier, yAcceptLanguage, yUserId, Guid.Parse(yCorrelationId));

		httpContext.Features.Set<TenantHttpFeature>(new TenantHttpFeature(tenantContext));
	}
}
