using Agrio.Bo.PIM.ApiBase.Features.Products.GetProduct;
using YaverMinimalApi.Features.Products.Entities;

namespace YaverMinimalApi.Features.Products.Get;

public class Mapper : Mapper<Request, Response, ProductEntity>
{
    public override Response FromEntity(ProductEntity e)
    {
        return new Response(
            e.Id,
            e.IsOutOfStock,
            e.Title,
            e.Quantity
        );
    }
}