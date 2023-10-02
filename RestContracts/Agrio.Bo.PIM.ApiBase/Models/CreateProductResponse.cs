namespace Agrio.Bo.PIM.ApiBase.Models;

public class CreateProductResponse {
	public Guid Id { get; set; }
	public bool IsOutOfStock { get; set; }
	public string Title { get; set; }
	public int Quantity { get; set; }
	public string Description { get; set; }
}
