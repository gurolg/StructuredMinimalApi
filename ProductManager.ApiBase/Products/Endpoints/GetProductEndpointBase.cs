using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using ProductManager.ApiBase.Products.Dtos;

namespace ProductManager.ApiBase.Products.Endpoints;

public abstract class GetProductEndpointBase : IYaverEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapGet("/products/{id}", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromRoute(Name = "id")][Required] Guid id)
            => HandleAsync(acceptLanguage, id));

    abstract public Task<Results<Ok<ProductDto>, NotFound>> HandleAsync(
        string acceptLanguage,
        Guid id);
}
