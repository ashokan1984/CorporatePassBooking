using AutoMapper;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public class AddVisitorHandler(IUnitOfWork unitOfWork, IVisitorRepository visitorRepository, IMapper mapper) : IRequestHandler<AddVisitorRequest, AddVisitorResponse>
    {
        public async Task<AddVisitorResponse> Handle(AddVisitorRequest request,
           CancellationToken cancellationToken)
        {
            var visitor = mapper.Map<Domain.Entities.Visitor>(request);
            visitorRepository.Create(visitor);
            await unitOfWork.Save(cancellationToken);

            return mapper.Map<AddVisitorResponse>(visitor);
        }
    }
}
