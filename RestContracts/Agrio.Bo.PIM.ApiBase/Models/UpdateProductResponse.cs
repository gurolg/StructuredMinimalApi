namespace Agrio.Bo.PIM.ApiBase.Models;

public record UpdateProductResponse(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
