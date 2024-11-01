using AutoMapper;
using CorporatePassBooking.Application.Common.Exceptions;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Update
{
    public class UpdateVisitorHandler(IUnitOfWork unitOfWork, IVisitorRepository visitorRepository, IMapper mapper) : IRequestHandler<UpdateVisitorRequest, UpdateVisitorResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IVisitorRepository _visitorRepository = visitorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UpdateVisitorResponse> Handle(UpdateVisitorRequest request, CancellationToken cancellationToken)
        {
            // Retrieve the existing visitor from the repository
            var visitor = await _visitorRepository.Get(request.Id, cancellationToken) ?? throw new NotFoundException("Visitor not found", request.Id);

            // Map the updated values from the request onto the existing visitor entity
            _mapper.Map(request, visitor);

            // Perform the update in the repository
            _visitorRepository.Update(visitor);

            // Save changes via UnitOfWork
            await _unitOfWork.Save(cancellationToken);

            // Map the updated entity back to the response model
            return _mapper.Map<UpdateVisitorResponse>(visitor);
        }
    }
}
