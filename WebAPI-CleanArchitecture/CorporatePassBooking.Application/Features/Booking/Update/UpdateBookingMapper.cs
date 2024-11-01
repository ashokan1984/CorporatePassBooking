using AutoMapper;
using CorporatePassBooking.Domain.Entities;

namespace CorporatePassBooking.Application.Features.Booking.Update
{
    public class UpdateBookingMapper : Profile
    {
        public UpdateBookingMapper()
        {
            CreateMap<UpdateBookingRequest, Domain.Entities.Booking>()
                .ForMember(member => member.Status, map => map.MapFrom(u => BookingStatusEnum.Confirmed));
            CreateMap<Domain.Entities.Booking, UpdateBookingResponse>();
        }
    }
}
