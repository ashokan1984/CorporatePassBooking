using AutoMapper;
using CorporatePassBooking.Application.Features.Booking.Get.ById;
using CorporatePassBooking.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Get.ByVisitorId
{
    public sealed class GetBookingByVisitorIdHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetBookingByVisitorIdRequest, List<GetBookingByVisitorIdResponse>>
    {
        public async Task<List<GetBookingByVisitorIdResponse>> Handle(GetBookingByVisitorIdRequest request, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.Get(r => r.VisitorId == request.VisitorId, 
                                booking => booking.Visitor, booking => booking.Facility, booking => booking.Facility.Amenities);
            return mapper.Map<List<GetBookingByVisitorIdResponse>>(booking);
        }
    }
}
