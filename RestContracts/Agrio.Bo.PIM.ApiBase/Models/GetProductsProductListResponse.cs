using System.Collections.Generic;


namespace Agrio.Bo.PIM.ApiBase.Models;

public record GetProductsResponse(
	int? TotalCount,
	List<ProductListItem> Items);
