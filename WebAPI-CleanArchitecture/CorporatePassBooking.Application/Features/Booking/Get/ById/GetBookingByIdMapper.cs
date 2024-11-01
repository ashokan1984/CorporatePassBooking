using AutoMapper;

namespace CorporatePassBooking.Application.Features.Booking.Get.ById
{
    public class GetBookingByIdMapper : Profile
    {
        public GetBookingByIdMapper() {

            CreateMap<Domain.Entities.Booking, GetBookingByIdResponse>()
                    .ForMember(mem => mem.Visitor, opt => opt.MapFrom(s => s.Visitor))
                    .ForMember(mem => mem.Facility, opt => opt.MapFrom(s => s.Facility));
        }
    }
}
