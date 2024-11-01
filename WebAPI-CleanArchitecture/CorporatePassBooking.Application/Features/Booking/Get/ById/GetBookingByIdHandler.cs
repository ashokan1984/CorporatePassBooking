using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Get.ById
{
    public sealed class GetBookingByIdHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetBookingByIdRequest, GetBookingByIdResponse>
    {
        public Task<GetBookingByIdResponse> Handle(GetBookingByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
