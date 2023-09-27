using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Models;

public class UpdateProductBody {

	public bool IsOutOfStock { get; set; }

	public string Title { get; set; }

	public int Quantity { get; set; }
}

public class UpdateProductBodyValidator : AbstractValidator<UpdateProductBody> {
	public UpdateProductBodyValidator() {
		// RuleFor(x => x.AcceptLanguage).NotEmpty();
		RuleFor(x => x.Title).NotEmpty();
		RuleFor(x => x.Title).NotNull();

		RuleFor(x => x.Quantity).NotEqual(-1);
	}
}

