using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class UpdateWalkDTOValidator : AbstractValidator<UpdateWalkDTO>
    {
        public UpdateWalkDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Length).NotEmpty().WithMessage("Length is required");
            RuleFor(x => x.RegionId).NotEmpty().WithMessage("RegionId is required");
            RuleFor(x => x.WalkDifficultyId).NotEmpty().WithMessage("WalkDifficultyId is required");
        }
    }
}
