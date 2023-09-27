using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Models;

/// <summary>
/// Represents a request to retrieve a list of products.
/// </summary>
public class GetProductsRequest {
	/// <summary>
	/// Gets or sets the language code for the desired response format.
	/// </summary>
	[FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }
	/// <summary>
	/// Gets or sets the maximum number of products to return.
	/// </summary>
	[BindFrom("limit")] public int? Limit { get; set; }
	[BindFrom("offset")] public int? Offset { get; set; }
	[BindFrom("term")] public string Term { get; set; }
	[BindFrom("sort")] public string Sort { get; set; }
}

public class GetProductsRequestValidator : Validator<GetProductsRequest> {
	public GetProductsRequestValidator() {
		// RuleFor(x => x.AcceptLanguage).NotEmpty();
		RuleFor(x => x.Limit).GreaterThan(0).LessThan(100);
		RuleFor(x => x.Term).NotNull().NotEmpty();
	}
}
