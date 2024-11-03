using AutoMapper;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Get.ById
{
    public sealed class GetBookingByIdHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetBookingByIdRequest, GetBookingByIdResponse>
    {
        public async Task<GetBookingByIdResponse> Handle(GetBookingByIdRequest request, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.Get(request.ID, cancellationToken, x => x.Facility, x => x.Visitor, a => a.Facility.Amenities);
            return mapper.Map<GetBookingByIdResponse>(booking);
        }

    }
}
