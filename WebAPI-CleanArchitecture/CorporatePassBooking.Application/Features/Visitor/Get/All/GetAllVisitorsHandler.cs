using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Get.All
{
    public sealed class GetAllVisitorsHandler(IVisitorRepository visitorsRepository, IMapper mapper) : IRequestHandler<GetAllVisitorsRequest, List<GetAllVisitorsResponse>>
    {
        public async Task<List<GetAllVisitorsResponse>> Handle(GetAllVisitorsRequest request, CancellationToken cancellationToken)
        {
            var visitors = await visitorsRepository.GetAll(cancellationToken);
            return mapper.Map<List<GetAllVisitorsResponse>>(visitors);
        }
    }
}
