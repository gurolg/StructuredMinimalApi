using System.Collections.Generic;

namespace Agrio.PIM.ServiceBase.Features.Products.GetProducts;

public class GetProductsCommand : ICommand<GetProductsResult>
{
	public string AcceptLanguage { get; set; }
	public int? Limit { get; set; }
	public int? Offset { get; set; }
	public string Term { get; set; }
	public string Sort { get; set; }
}
//TODO: Add Validation

public class GetProductsResult
{
	public int? TotalCount { get; set; } = 0;
	public List<ProductListItem> Items { get; set; }
}

public record ProductListItem(
		Guid Id,
		bool IsOutOfStock = false,
		string Title = "",
		int Quantity = 0);