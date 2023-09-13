using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProductManager.ApiBase.Products.Dtos;

public record ProductListDto(
    [property: DataMember(Name = "totalCount")] int? TotalCount,
    [property: DataMember(Name = "items")] List<ProductListItemDto> Items);