namespace Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;

public class UpdateProductCommand : ICommand<UpdateProductResult> {
	public Guid Id { get; init; }
	public bool IsOutOfStock { get; init; }
	public string Title { get; init; }
	public int Quantity { get; init; }
}
//TODO: Add Validation

public record UpdateProductResult(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "",
	int Quantity = 0);
