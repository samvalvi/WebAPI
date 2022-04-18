using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class AddRegionDTOValidator : AbstractValidator<AddRegionDTO>
    {
        public AddRegionDTOValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Area).NotEmpty().WithMessage("Area is required");
            RuleFor(x => x.Lat).NotEmpty().WithMessage("Lat is required");
            RuleFor(x => x.Long).NotEmpty().WithMessage("Long is required");
            RuleFor(x => x.Population).NotEmpty().WithMessage("Population is required");
        }
    }
}
