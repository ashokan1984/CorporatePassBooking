using MediatR;

namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed record GetFacilityByIdRequest(Guid Id) : IRequest<GetFacilityByIdResponse>;
}
