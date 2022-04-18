using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class AddWalkDifficultyDTOValidator : AbstractValidator<AddWalkDifficultyDTO>
    {
        public AddWalkDifficultyDTOValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(55).WithMessage("Code is required and must be less than 55 characters");
        }
    }
}
