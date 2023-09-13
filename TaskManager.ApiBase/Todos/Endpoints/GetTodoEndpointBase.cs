using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using TaskManager.ApiBase.Todos.Dtos;

namespace TaskManager.ApiBase.Todos.Endpoints;

public abstract class GetTodoEndpointBase //: IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapGet("/todos/{id}", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromRoute(Name = "id")][Required] Guid id)
            => HandleAsync(acceptLanguage, id));

    abstract public Task<Results<Ok<TodoDto>, NotFound>> HandleAsync(
        string acceptLanguage,
        Guid id);
}
