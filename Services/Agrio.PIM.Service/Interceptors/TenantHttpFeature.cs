namespace Agrio.PIM.Service.Interceptors;

public record TenantHttpFeature(TenantContext TenantContext);

public record TenantContext(string TenantIdentifier, string Language, Guid UserId, Guid CorrelationId);
