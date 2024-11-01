using CorporatePassBooking.Application.Features.Visitor.Get.All;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Get.All
{
    public sealed record GetAllBookingsRequest : IRequest<List<GetAllBookingsResponse>>;
}
