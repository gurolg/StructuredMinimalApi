namespace Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

public class CreateProductCommand : ICommand<CreateProductResult> {
	public string Title { get; init; }
}

//TODO: Add Validation

public class CreateProductResult {
	public Guid Id { get; init; }
	public bool IsOutOfStock { get; init; }
	public string Title { get; init; }
	public int Quantity { get; init; }
	public string Description { get; init; }
}
