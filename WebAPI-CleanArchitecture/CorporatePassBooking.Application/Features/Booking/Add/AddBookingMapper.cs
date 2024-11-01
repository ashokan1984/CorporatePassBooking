using AutoMapper;
using CorporatePassBooking.Domain.Entities;

namespace CorporatePassBooking.Application.Features.Booking.Add
{
    public class AddBookingMapper : Profile
    {
        public AddBookingMapper()
        {
            CreateMap<AddBookingRequest, Domain.Entities.Booking>()
                .ForMember(member => member.Status, map => map.MapFrom(u => BookingStatusEnum.Confirmed));
            CreateMap<Domain.Entities.Booking, AddBookingResponse>();
        }
    }
}
