using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TaskManager.ApiBase.Todos.Dtos;

namespace TaskManager.ApiBase.Todos.Endpoints;


public abstract class UpdateTodoEndpointBase : IYaverEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapPut("/todos/{id}", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromRoute(Name = "id")][Required] Guid id,
            [FromBody] TodoUpdateDto payload,
            CancellationToken cancellationToken)
             => HandleAsync(acceptLanguage, id, payload, cancellationToken));


    abstract public Task<Results<Ok, NotFound, BadRequest>> HandleAsync(
        string acceptLanguage,
        Guid id,
        TodoUpdateDto payload,
        CancellationToken cancellationToken);
}
