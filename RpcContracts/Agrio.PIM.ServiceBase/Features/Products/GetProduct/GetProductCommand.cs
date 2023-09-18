namespace Agrio.PIM.ServiceBase.Features.Products.GetProduct;

public class GetProductCommand : ICommand<GetProductResult> {
	public Guid Id { get; init; }
}
//TODO: Add Validation

public record GetProductResult(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
