using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Get.All
{
    public sealed class GetAllBookingsHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetAllBookingsRequest, List<GetAllBookingsResponse>>
    {
        public async Task<List<GetAllBookingsResponse>> Handle(GetAllBookingsRequest request, CancellationToken cancellationToken)
        {
            var bookings = await bookingRepository.GetAllNoTracking(e => e.Facility, y => y.Visitor, a=> a.Facility.Amenities);
            return mapper.Map<List<GetAllBookingsResponse>>(bookings);
        }
    }
}
