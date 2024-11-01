using CorporatePassBooking.Application.Features.Booking.Add;
using CorporatePassBooking.Application.Features.Visitor.Add;
using CorporatePassBooking.Application.Features.Visitor.Get.All;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;
using CorporatePassBooking.Application.Features.Visitor.Update;
using CorporatePassBooking.WebAPI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CorporatePassBooking.Application.Features.Booking.Update;
using CorporatePassBooking.Application.Features.Booking.Get.All;
using CorporatePassBooking.Application.Features.Booking.Get.ById;
using CorporatePassBooking.Application.Features.Booking.Get.ByVisitorId;

namespace CorporatePassBooking.WebAPI.Controllers
{
    public class BookingController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddBookingResponse>> Create(AddBookingRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateVisitorResponse>> Update(UpdateBookingRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllBookingsResponse>> GetAll([FromQuery] GetAllBookingsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<GetBookingByIdResponse>> GetById(Guid bookingId,
            CancellationToken cancellationToken)
        {
            var request = new GetBookingByIdRequest(bookingId);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{visitorId}")]
        public async Task<ActionResult<GetBookingByIdResponse>> GetByVisitorId(Guid visitorId,
            CancellationToken cancellationToken)
        {
            var request = new GetBookingByVisitorIdRequest(visitorId);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
