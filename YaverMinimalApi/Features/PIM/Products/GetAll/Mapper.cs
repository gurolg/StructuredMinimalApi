using Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;
using YaverMinimalApi.Features.Products.Entities;

namespace YaverMinimalApi.Features.Products.GetAll;

public class Mapper : Mapper<Request, ProductListResponse, List<ProductEntity>>
{
    public override ProductListResponse FromEntity(List<ProductEntity> e)
    {
        return new ProductListResponse(
            e.Count,
            e.Select(e => new ProductListItem(
                e.Id,
                e.IsOutOfStock,
                e.Title,
                e.Quantity
            )).ToList()
        );
    }
}