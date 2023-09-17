using Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;
using YaverMinimalApi.Features.Products.Entities;

namespace YaverMinimalApi.Features.Products.Create;

public class Mapper : Mapper<Request, Response, ProductEntity>
{
    public override ProductEntity ToEntity(Request r)
    {
        return new ProductEntity
        {
            IsOutOfStock = false,
            Title = r.Title,
            Id = Guid.NewGuid()
        };
    }

    public override Response FromEntity(ProductEntity e)
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