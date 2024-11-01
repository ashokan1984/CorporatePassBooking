using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed class AddFacilityHandler(IUnitOfWork unitOfWork, IFacilityRepository facilityRepository, IMapper mapper) : IRequestHandler<AddFacilityRequest, AddFacilityResponse>
    {
        public async Task<AddFacilityResponse> Handle(AddFacilityRequest request,
           CancellationToken cancellationToken)
        {
            var facility = mapper.Map<Domain.Entities.Facility>(request);

            facilityRepository.Create(facility);
            await unitOfWork.Save(cancellationToken);

            return mapper.Map<AddFacilityResponse>(facility);
        }
    }
}
