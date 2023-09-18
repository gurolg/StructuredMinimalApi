namespace Agrio.PIM.Service.Features.Entities;

public class ProductEntity {
	public Guid Id { get; init; } = Guid.NewGuid();
	public bool IsOutOfStock { get; set; }
	public string Title { get; set; } = string.Empty;
	public int Quantity { get; set; }
}
