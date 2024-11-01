using AutoMapper;
using CorporatePassBooking.Application.Common.Exceptions;
using CorporatePassBooking.Application.Features.Booking.Add;
using CorporatePassBooking.Application.Features.Facility.Get.All;
using CorporatePassBooking.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Update
{
    public class UpdateBookingHandler(IUnitOfWork unitOfWork,
        IFacilityRepository facilityRepository,
        IVisitorRepository visitorRepository,
        IBookingRepository bookingRepository,
        IMapper mapper) : IRequestHandler<UpdateBookingRequest, UpdateBookingResponse>
    {
        public async Task<UpdateBookingResponse> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
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
            var booking = await bookingRepository.Get(request.ID, cancellationToken);

            if(request.Quantity > booking.Quantity)
            {
                var difference = request.Quantity - booking.Quantity;
                if(difference > facility.AvailableCapacity)
                {
                    throw new BadRequestException("Tickets not available");
                }
                else
                {
                    facility.AvailableCapacity = facility.AvailableCapacity - difference;
                }
            }
            else if(request.Quantity < booking.Quantity)
            {
                var difference = booking.Quantity - request.Quantity;
                facility.AvailableCapacity = facility.AvailableCapacity + difference;
            }
            facilityRepository.Update(facility);

            mapper.Map(request,booking);
            bookingRepository.Update(booking);
            

            facility.AvailableCapacity = facility.AvailableCapacity - request.Quantity;
            facilityRepository.Update(facility);

            await unitOfWork.Save(cancellationToken);
            return mapper.Map<UpdateBookingResponse>(booking);
        }
    }
}
