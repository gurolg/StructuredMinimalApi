using System.ComponentModel.DataAnnotations;

using FluentValidation;

namespace Agrio.Bo.PIM.ApiBase.Models;
public class CreateProductBody {
	// [Required]
	// [StringLength(50, MinimumLength = 2)]
	public string Title { get; set; }
	public int Quantity { get; set; }
}


public class CreateProductRequestValidator : Validator<CreateProductBody> {
	public CreateProductRequestValidator() {
		RuleFor(x => x.Title).NotNull();
		RuleFor(x => x.Quantity).GreaterThan(0);

	}
}
