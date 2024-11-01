using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Get.ById
{
    public sealed record GetBookingByIdRequest(Guid ID) : IRequest<GetBookingByIdResponse>;
}
