using System.Collections.Generic;

namespace Agrio.PIM.ServiceBase.Features.Products.GetProducts;

public class GetProductsCommand : ICommand<GetProductsResult> {
	public string AcceptLanguage { get; init; }
	public int? Limit { get; init; }
	public int? Offset { get; init; }
	public string Term { get; init; }
	public string Sort { get; init; }
}
//TODO: Add Validation

public class GetProductsResult {
	public int? TotalCount { get; init; } = 0;
	public List<ProductListItem> Items { get; init; }
}

public record ProductListItem(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
