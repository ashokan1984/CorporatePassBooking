using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Facility.Get.All
{
    public sealed class GetAllFacilityHandler(IFacilityRepository facilityRepository, IMapper mapper) : IRequestHandler<GetAllFacilitiesRequest, List<GetAllFacilitiesResponse>>
    {
        public async Task<List<GetAllFacilitiesResponse>> Handle(GetAllFacilitiesRequest request,
           CancellationToken cancellationToken)
        {
            var facilities = await facilityRepository.GetAllNoTracking(x => x.Amenities);
            return mapper.Map<List<GetAllFacilitiesResponse>>(facilities);
        }
    }
}
