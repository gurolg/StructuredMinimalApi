using System.Collections.Generic;

namespace Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;

public class UpdateProductCommand : ICommand<UpdateProductResult>
{
	public Guid Id { get; set; }
	public bool IsOutOfStock { get; set; }
	public string Title { get; set; }
	public int Quantity { get; set; }
}
//TODO: Add Validation


public record UpdateProductResult(
		Guid Id,
		bool IsOutOfStock = false,
		string Title = "",
		int Quantity = 0);