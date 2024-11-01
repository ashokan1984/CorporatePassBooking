using CorporatePassBooking.Application.Features.Booking.Add;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Update
{
    public sealed record UpdateBookingRequest(Guid ID, Guid FacilityId, Guid VisitorId, int Quantity, DateTime BookingDateTime) : IRequest<UpdateBookingResponse>;
}
