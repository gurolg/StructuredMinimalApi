using System;

namespace ProductManager.ApiBase.Products.Dtos;

public record ProductUpdateDto(
				bool IsOutOfStock = false,
				string Title = "");