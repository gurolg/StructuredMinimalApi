using Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;
using YaverMinimalApi.Features.Products.Entities;

namespace YaverMinimalApi.Features.Products.Update;

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

    public override ProductEntity UpdateEntity(Request r, ProductEntity e)
    {
        e.IsOutOfStock = r.IsOutOfStock;
        e.Title = r.Title;
        e.Quantity = r.Quantity;
        return e;
    }
}