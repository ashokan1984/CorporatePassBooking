using AutoMapper;

namespace CorporatePassBooking.Application.Features.Booking.Get.All
{
    public class GetAllBookingsMapper : Profile
    {
        public GetAllBookingsMapper()
        {
            CreateMap<Domain.Entities.Booking, GetAllBookingsResponse>()
                .ForMember(mem => mem.Visitor, opt => opt.MapFrom(s => s.Visitor))
                .ForMember(mem => mem.Facility, opt => opt.MapFrom(s => s.Facility));

        }
    }
}
