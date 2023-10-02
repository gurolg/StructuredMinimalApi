using System.Text.Json;

using Agrio.Bo.PIM.ApiBase.Models;

using FluentValidation;

using Microsoft.AspNetCore.Http.HttpResults;

using ProblemDetails = FastEndpoints.ProblemDetails;

namespace Agrio.Bo.PIM.ApiBase.Tags.Products;

internal static class JsonOptions {
	public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions(JsonSerializerDefaults.Web);
}

/// <summary>
/// Represents a request to create a product.
/// </summary>
/// <param name="AcceptLanguage"></param>
/// <param name="Body"></param>
public class CreateProductRequest {
	[FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }

	[BindFrom("tenant")] public string TenantIdentifier { get; set; }

	public string Id { get; set; }

	[FromQueryParams] public int? TotalCount { get; set; }

	[FromClaim("sub")] public string UserId { get; set; }

	[FromBody] public CreateProductBody Body { get; set; }
}

public class CreateProductRequestVali : Validator<CreateProductRequest> {
	public CreateProductRequestVali() {
		// RuleFor(x => x.TotalCount).NotNull().GreaterThan(0);
		RuleFor(customer => customer.Body).SetValidator(new CreateProductRequestValidator());
	}
}

public class CreateProductEndpointBase<TMapper> :
	Endpoint<CreateProductRequest, Results<Created<CreateProductResponse>, BadRequest, ProblemDetails, Conflict,
		ProblemHttpResult, JsonHttpResult<object>>, TMapper>
	where TMapper : IMapper {
	public override void Configure() {
		Post("/{tenant}/products");
		// RequestBinder(new CreateProductRequestBinder());
		Roles("admin");
		Validator<CreateProductRequestVali>();
	}
}

public class GetProductEndpointBase<TMapper> :
	Endpoint<GetProductRequest, Results<Ok<GetProductResponse>, NotFound, ProblemDetails>, TMapper>
	where TMapper : IMapper {
	public override void Configure() {
		// Verbs(Http.GET);
		Get("/products/{id}");
		AllowAnonymous();
	}
}

public class GetAllProductEndpointBase<TMapper> :
	Endpoint<GetProductsRequest, GetProductsResponse, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Get("/products");
		AllowAnonymous();
	}
}

public class UpdateProductRequest {
	[FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }

	public Guid Id { get; set; }

	[FastEndpoints.FromBody] public UpdateProductBody Body { get; set; }
}

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest> {
	public UpdateProductRequestValidator() {
		RuleFor(r => r.Body).SetValidator(new UpdateProductBodyValidator());
		RuleFor(r => r.Body.Title).NotNull();
	}
}

public class UpdateProductEndpointBase<TMapper> :
	Endpoint<UpdateProductRequest, Object, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Put("/products/{id}");
		// AllowAnonymous();
		Roles("KYC2");
	}
}
