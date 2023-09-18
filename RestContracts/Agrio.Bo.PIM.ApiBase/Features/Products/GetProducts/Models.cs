using System.Collections.Generic;

using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;

public class Request {
	[FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }

	// [FromQueryParams]
	[BindFrom("limit")] public int? Limit { get; set; }

	// [FromQueryParams]
	[BindFrom("offset")] public int? Offset { get; set; }

	// [FromQueryParams]
	[BindFrom("term")] public string Term { get; set; }

	// [FromQueryParams]
	[BindFrom("sort")] public string Sort { get; set; }
}

public class Validator : Validator<Request> {
	public Validator() {
		// RuleFor(x => x.AcceptLanguage).NotEmpty();
		RuleFor(x => x.Limit).GreaterThan(0).LessThan(100);
	}
}

public record ProductListResponse(
	int? TotalCount,
	List<ProductListItem> Items);

public record ProductListItem(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
