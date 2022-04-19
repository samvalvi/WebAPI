using FluentValidation;
using WebAPI.Models.DTO;

namespace WebAPI.Validation
{
    public class AddUserDTOValidator : AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        }
    }
}
