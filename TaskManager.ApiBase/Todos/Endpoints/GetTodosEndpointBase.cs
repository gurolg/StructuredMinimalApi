using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using TaskManager.ApiBase.Todos.Dtos;

namespace TaskManager.ApiBase.Todos.Endpoints;

public abstract class GetTodosEndpointBase : IYaverEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app) =>
        app.MapGet("/Todos", (
            [FromHeader(Name = "Accept-Language")][Required] string acceptLanguage,
            [FromQuery(Name = "limit")][Range(1, 100)] int? limit,
            [FromQuery(Name = "offset")] int? offset,
            [FromQuery(Name = "term")] string term,
            [FromQuery(Name = "sort")] string sort)
            => HandleAsync(acceptLanguage, limit, offset, term, sort));

    abstract public Task<Results<Ok<TodoListDto>, NotFound>> HandleAsync(
        string acceptLanguage,
        int? limit,
        int? offset,
        string term = "",
        string sort = "");
}
