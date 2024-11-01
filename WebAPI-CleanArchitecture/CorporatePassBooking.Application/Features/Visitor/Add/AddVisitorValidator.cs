using CorporatePassBooking.Application.Features.Visitor.Add;
using FluentValidation;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed class AddVisitorValidator : AbstractValidator<AddVisitorRequest>
    {
        public AddVisitorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("PhoneNumber must be a valid international phone number.")
                .MinimumLength(7)
                .WithMessage("PhoneNumber must be at least 7 digits long.")
                .MaximumLength(15)
                .WithMessage("PhoneNumber cannot exceed 15 digits.");
        }
    }
}
