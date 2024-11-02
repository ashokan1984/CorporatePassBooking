using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed class GetFacilityByIdHandler(IFacilityRepository facilityRepository, IMapper mapper) : IRequestHandler<GetFacilityByIdRequest, GetFacilityByIdResponse>
    {
        public async Task<GetFacilityByIdResponse> Handle(GetFacilityByIdRequest request, CancellationToken cancellationToken)
        {
            var visitors = await facilityRepository.Get(request.Id, cancellationToken, x => x.Amenities);
            return mapper.Map<GetFacilityByIdResponse>(visitors);
        }
    }
}
