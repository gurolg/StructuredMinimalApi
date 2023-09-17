using Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

namespace YaverMinimalApi.Features.PIM.Products.Create;

public class Mapper : Mapper<Request, Response, CreateProductResult>
{

    public override Response FromEntity(CreateProductResult e)
    {
        return new Response
        {
            Id = e.Id,
            IsOutOfStock = e.IsOutOfStock,
            Title = e.Title,
            Quantity = e.Quantity
        };
    }
}