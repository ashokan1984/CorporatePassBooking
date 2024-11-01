using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Update
{
    public sealed record UpdateVisitorRequest(Guid Id, string Name, string Email, string PhoneNumber) : IRequest<UpdateVisitorResponse>;

}
