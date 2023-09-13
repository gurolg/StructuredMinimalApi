using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TaskManager.ApiBase.Todos.Dtos;

namespace TaskManager.ApiBase.Todos.Endpoints;


public abstract class CreateTodoEndpointBase //: IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapPost("/todos", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromBody] TodoCreateDto payload,
            CancellationToken cancellationToken)
             => HandleAsync(acceptLanguage, payload, cancellationToken));


    abstract public Task<Created<TodoDto>> HandleAsync(
        string acceptLanguage,
        TodoCreateDto payload,
        CancellationToken cancellationToken);
}
