using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Get.ById
{
    public sealed class GetVisitorByIdHandler(IVisitorRepository visitorsRepository, IMapper mapper) : IRequestHandler<GetVisitorByIdRequest, GetVisitorByIdResponse>
    {
        public async Task<GetVisitorByIdResponse> Handle(GetVisitorByIdRequest request, CancellationToken cancellationToken)
        {
            var visitors = await visitorsRepository.Get(request.Id, cancellationToken);
            return mapper.Map<GetVisitorByIdResponse>(visitors);
        }
    }
}
