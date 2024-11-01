using AutoMapper;
using CorporatePassBooking.Application.Features.Facility.Get.All;

namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed class GetFacilityByIdMapper : Profile
    {
        public GetFacilityByIdMapper()
        {
            CreateMap<Domain.Entities.Facility, GetFacilityByIdResponse>().ForMember(member => member.Amenities, u => u.MapFrom(s => s.Amenities.Select(r => r.Name)));
        }
    }
}
