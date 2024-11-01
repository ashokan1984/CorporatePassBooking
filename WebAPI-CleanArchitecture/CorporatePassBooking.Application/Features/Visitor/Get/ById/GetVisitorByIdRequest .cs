using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Get.ById
{
    public sealed record GetVisitorByIdRequest(Guid Id) : IRequest<GetVisitorByIdResponse>;
}
