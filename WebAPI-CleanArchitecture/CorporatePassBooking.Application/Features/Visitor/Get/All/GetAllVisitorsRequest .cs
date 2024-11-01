using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Get.All
{
    public sealed record GetAllVisitorsRequest : IRequest<List<GetAllVisitorsResponse>>;
}
