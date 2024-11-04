using FluentValidation;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed class AddFacilityValidator : AbstractValidator<AddFacilityRequest>
    {
        public AddFacilityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(50);

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Type is required.")
                .MaximumLength(50);

            RuleFor(x => x.TotalCapacity)
                .GreaterThan(0)
                .WithMessage("Capacity must be greater than zero.");

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("Location is required.")
                .MaximumLength(50);

        }
    }
}
