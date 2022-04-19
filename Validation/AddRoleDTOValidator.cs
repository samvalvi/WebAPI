using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class AddRoleDTOValidator : AbstractValidator<AddRoleDTO>
    {
        public AddRoleDTOValidator()
        {
            RuleFor(x => x.UserRole).NotEmpty().WithMessage("User Role is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required");
        }
    }
}
