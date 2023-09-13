using System;

namespace ProductManager.ApiBase.Products.Dtos;

public record ProductDto(
			Guid Id,
			bool IsOutOfStock = false,
			string Title = "");
