using Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;

namespace YaverMinimalApi.Features.PIM.Products.GetAll;

public class Mapper : Mapper<Request, ProductListResponse, GetProductsResult>
{
    public override ProductListResponse FromEntity(GetProductsResult e)
    {
        return new ProductListResponse(
            e.TotalCount,
            e.Items.Select(e => new Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts.ProductListItem(
                e.Id,
                e.IsOutOfStock,
                e.Title,
                e.Quantity
            )).ToList()
        );
    }
}