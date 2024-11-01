using AutoMapper;

namespace CorporatePassBooking.Application.Features.Facility.Get.All;

public sealed class GetAllFacilitiesMapper : Profile
{
    public GetAllFacilitiesMapper()
    {
        CreateMap<Domain.Entities.Facility, GetAllFacilitiesResponse>().ForMember(member => member.Amenities, u => u.MapFrom(s => s.Amenities.Select(r => r.Name)));
    }
}

