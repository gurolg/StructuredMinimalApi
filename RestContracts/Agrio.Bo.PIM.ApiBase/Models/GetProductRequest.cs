using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Models;

public class GetProductRequest {
	// [FromHeader]
	[FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }

	// [From]
	[BindFrom("id")] public Guid Id { get; set; }
}

public class GetProductRequestValidator : Validator<GetProductRequest> {
	public GetProductRequestValidator() {
		RuleFor(x => x.Id).NotEmpty();
	}
}
