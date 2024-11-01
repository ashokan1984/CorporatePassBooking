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
            if (!await facilityRepository.Any(request.FacilityId, cancellationToken))
                throw new BadRequestException("Invalid facility id");
            if (!await visitorRepository.Any(request.VisitorId, cancellationToken))
                throw new BadRequestException("Invalid Visitor id");

            if (await bookingRepository.Any(booking => booking.FacilityId.Equals(request.FacilityId)
                    && booking.VisitorId.Equals(request.VisitorId)
                    && booking.BookingDateTime.Date.Equals(request.BookingDateTime.Date)))
                throw new BadRequestException("This booking conflicts with an existing booking.");

            var facility = (await facilityRepository.Get(request.FacilityId, cancellationToken));
            if (request.Quantity > facility.AvailableCapacity)
            {
                if (facility.AvailableCapacity == 0)
                    throw new BadRequestException("Tickets sold out");
                else
                    throw new BadRequestException($"Only {facility.AvailableCapacity} tickets are available");
            }

            var booking = mapper.Map<Domain.Entities.Booking>(request);
            bookingRepository.Create(booking);
            await unitOfWork.Save(cancellationToken);

            facility.AvailableCapacity = facility.AvailableCapacity - request.Quantity;
            facilityRepository.Update(facility);

            return mapper.Map<AddBookingResponse>(booking);
        }
    }
}
