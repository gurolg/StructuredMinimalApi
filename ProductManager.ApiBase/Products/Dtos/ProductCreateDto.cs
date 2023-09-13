using System;

namespace ProductManager.ApiBase.Products.Dtos;

public record ProductCreateDto(
				Guid Id,
				bool IsOutOfStock = false,
				string Title = "");