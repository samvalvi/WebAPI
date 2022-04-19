using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class UpdateRoleDTOValidator : AbstractValidator<UpdateRoleDTO>
    {
        public UpdateRoleDTOValidator()
        {
            RuleFor(x => x.UserRole).NotEmpty().WithMessage("User Role is required");
        }
    }
}
