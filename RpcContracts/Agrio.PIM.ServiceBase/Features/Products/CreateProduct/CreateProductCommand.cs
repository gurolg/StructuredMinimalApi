namespace Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

public class CreateProductCommand : ICommand<CreateProductResult>
{
    public string Title { get; set; }
}

//TODO: Add Validation


public class CreateProductResult
{
    public Guid Id { get; set; }
    public bool IsOutOfStock { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
}