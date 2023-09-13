using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TaskManager.ApiBase.Todos.Dtos;

public record TodoListDto(
    [property: DataMember(Name = "totalCount")] int? TotalCount,
    [property: DataMember(Name = "items")] List<TodoListItemDto> Items);