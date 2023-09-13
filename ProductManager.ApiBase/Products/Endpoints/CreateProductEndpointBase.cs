using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductManager.ApiBase.Products.Dtos;

namespace ProductManager.ApiBase.Products.Endpoints;


public abstract class CreateProductEndpointBase //: IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapPost("/products", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromBody] ProductCreateDto payload,
            CancellationToken cancellationToken)
             => HandleAsync(acceptLanguage, payload, cancellationToken));


    abstract public Task<Created<ProductDto>> HandleAsync(
        string acceptLanguage,
        ProductCreateDto payload,
        CancellationToken cancellationToken);
}
