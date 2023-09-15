using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductManager.ApiBase.Products.Dtos;

namespace ProductManager.ApiBase.Products.Endpoints;

public abstract class UpdateProductEndpointBase : IYaverEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapPut("/products/{id}", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromRoute(Name = "id")][Required] Guid id,
            [FromBody] ProductUpdateDto payload,
            CancellationToken cancellationToken)
             => HandleAsync(acceptLanguage, id, payload, cancellationToken));


    abstract public Task<Results<Ok, NotFound, BadRequest>> HandleAsync(
        string acceptLanguage,
        Guid id,
        ProductUpdateDto payload,
        CancellationToken cancellationToken);
}
