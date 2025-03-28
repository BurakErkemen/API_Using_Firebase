using FluentValidation;

namespace App.Services.Services.UserServices.Update
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.BirtDay).NotEmpty().WithMessage("BirtDay is required");
        }
    }
}
