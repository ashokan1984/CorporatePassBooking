using CorporatePassBooking.Application.Features.Visitor.Add;
using CorporatePassBooking.Application.Features.Visitor.Get.All;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;
using CorporatePassBooking.Application.Features.Visitor.Update;
using CorporatePassBooking.WebAPI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CorporatePassBooking.WebAPI.Controllers
{
    public class VisitorController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddVisitorResponse>> Create(AddVisitorRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateVisitorResponse>> Update(UpdateVisitorRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllVisitorsResponse>> GetAll([FromQuery] GetAllVisitorsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{visitorId}")]
        public async Task<ActionResult<GetVisitorByIdResponse>> GetById(Guid visitorId,
            CancellationToken cancellationToken)
        {
            var request = new GetVisitorByIdRequest(visitorId);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
