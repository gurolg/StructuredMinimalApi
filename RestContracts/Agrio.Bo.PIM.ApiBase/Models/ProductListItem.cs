namespace Agrio.Bo.PIM.ApiBase.Models;

public record ProductListItem(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
