using CorporatePassBooking.Application.Features.Facility.Get.All;
using CorporatePassBooking.Application.Features.Facility.Get.ById;
using CorporatePassBooking.Application.Features.Visitor.Add;
using CorporatePassBooking.WebAPI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CorporatePassBooking.WebAPI.Controllers
{
    public class FacilityController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetAllFacilitiesResponse>> GetAll([FromQuery] GetAllFacilitiesRequest request,
           CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{facilityId}")]
        public async Task<ActionResult<GetFacilityByIdResponse>> GetById(Guid facilityId,
            CancellationToken cancellationToken)
        {
            var request = new GetFacilityByIdRequest(facilityId);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AddFacilityResponse>> Create(AddFacilityRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
