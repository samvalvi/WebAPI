using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class UpdateWalkDifficultyDTOValidator : AbstractValidator<UpdateWalkDifficultyDTO>
    {
        public UpdateWalkDifficultyDTOValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(55).WithMessage("Code is required and must be less than 55 characters");
        }
    }
}
