using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Add
{
    public sealed record AddBookingRequest(Guid FacilityId, Guid VisitorId, int Quantity, DateTime BookingDateTime) : IRequest<AddBookingResponse>;
}
