using AutoMapper;
using CorporatePassBooking.Application.Common.Exceptions;
using CorporatePassBooking.Application.Repository;
using MediatR;

namespace CorporatePassBooking.Application.Features.Booking.Add
{
    public class AddBookingHandler(IUnitOfWork unitOfWork,
        IFacilityRepository facilityRepository,
        IVisitorRepository visitorRepository,
        IBookingRepository bookingRepository, 
        IMapper mapper) : IRequestHandler<AddBookingRequest, AddBookingResponse>
    {
        public async Task<AddBookingResponse> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            if(! await facilityRepository.Any(request.FacilityId, cancellationToken))
                throw new BadRequestException("Invalid facility id");
            if(! await visitorRepository.Any(request.VisitorId, cancellationToken))
                throw new BadRequestException("Invalid Visitor id");

            var booking = mapper.Map<Domain.Entities.Booking>(request);
            bookingRepository.Create(booking);
            await unitOfWork.Save(cancellationToken);

            return mapper.Map<AddBookingResponse>(booking);
        }
    }
}
