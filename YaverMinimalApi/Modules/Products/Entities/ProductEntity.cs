namespace YaverMinimalApi.Modules.Products.Entities;

public record ProductEntity(Guid Id, bool IsOutOfStock, string Title = "");