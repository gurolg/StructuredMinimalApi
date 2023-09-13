using System;

namespace ProductManager.ApiBase.Products.Dtos;

public record ProductListItemDto(
	Guid Id,
	bool IsOutOfStock = false,
	string Title = "");