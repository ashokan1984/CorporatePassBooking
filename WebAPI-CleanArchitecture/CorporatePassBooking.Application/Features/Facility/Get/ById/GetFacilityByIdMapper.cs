using AutoMapper;

namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed class GetFacilityByIdMapper : Profile
    {
        public GetFacilityByIdMapper()
        {
            CreateMap<Domain.Entities.Facility, GetFacilityByIdResponse>();
        }
    }
}
