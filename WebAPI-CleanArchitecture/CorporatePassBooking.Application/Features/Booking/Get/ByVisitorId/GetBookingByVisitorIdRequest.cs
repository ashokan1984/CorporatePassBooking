using CorporatePassBooking.Application.Features.Booking.Get.ById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Get.ByVisitorId
{
    public sealed record GetBookingByVisitorIdRequest(Guid VisitorId) : IRequest<List<GetBookingByVisitorIdResponse>>;
}
