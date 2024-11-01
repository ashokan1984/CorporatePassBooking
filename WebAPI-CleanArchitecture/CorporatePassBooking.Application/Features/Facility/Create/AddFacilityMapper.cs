
using AutoMapper;
using CorporatePassBooking.Application.Features.Visitor.Add;
using CorporatePassBooking.Domain.Entities;

namespace CorporatePassBooking.Application.Features
{
    public sealed class AddFacilityMapper : Profile
    {
        public AddFacilityMapper()
        {
            CreateMap<AddFacilityRequest, Domain.Entities.Facility>().ForMember(facility => facility.Amenities,
                m => m.MapFrom(u => u.Amenities.Select(s => new Amenity
                             {
                                Name = s
                             })
                ));
            CreateMap<Domain.Entities.Facility, AddFacilityResponse>();
        }
    }
}
