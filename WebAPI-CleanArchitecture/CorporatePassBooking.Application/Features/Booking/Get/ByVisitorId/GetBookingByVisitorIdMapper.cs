using AutoMapper;

namespace CorporatePassBooking.Application.Features.Booking.Get.ByVisitorId
{
    public class GetBookingByVisitorIdMapper : Profile
    {
        public GetBookingByVisitorIdMapper()
        {
            CreateMap<Domain.Entities.Booking, GetBookingByVisitorIdResponse>()
                    .ForMember(mem => mem.Visitor, opt => opt.MapFrom(s => s.Visitor))
                    .ForMember(mem => mem.Facility, opt => opt.MapFrom(s => s.Facility));
        }
    }
}
