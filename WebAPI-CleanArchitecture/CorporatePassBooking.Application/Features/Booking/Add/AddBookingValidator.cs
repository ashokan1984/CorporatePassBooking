using FluentValidation;

namespace CorporatePassBooking.Application.Features.Booking.Add
{
    public class AddBookingValidator : AbstractValidator<AddBookingRequest>
    {
        public AddBookingValidator()
        {
            RuleFor(booking => booking.FacilityId).Must(m => m != Guid.Empty)
                .WithMessage("Invalid facility id");

            RuleFor(booking => booking.VisitorId).Must(m => m != Guid.Empty)
                .WithMessage("Invalid Visitor id");

            RuleFor(booking => booking.BookingDateTime)
                .NotEmpty().WithMessage("BookingDateTime is required.")
                .Must(date => date >= DateTime.Today)
                .WithMessage("BookingDate cannot be in the past.");
        }
    }
}
