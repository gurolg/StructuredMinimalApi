using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;

public class Request
{
    [BindFrom("Accept-Language")]
    // [FromHeader]
    public string AcceptLanguage { get; set; }

    public string Title { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.AcceptLanguage).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}

public class Response
{
    public Guid Id { get; set; }
    public bool IsOutOfStock { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
}