using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;

public class Request
{
    [BindFrom("Accept-Language")]
    // [FromHeader]
    public string AcceptLanguage { get; set; }

    // [From]
    [BindFrom("id")] public Guid Id { get; set; }

    [BindFrom("isOutOfStockd")] public bool IsOutOfStock { get; set; }

    [BindFrom("title")] public string Title { get; set; }

    [BindFrom("quantity")] public int Quantity { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.AcceptLanguage).NotEmpty();
        RuleFor(x => x.Id).NotEmpty();
    }
}

public record Response(
    Guid Id,
    bool IsOutOfStock = false,
    string Title = "",
    int Quantity = 0);