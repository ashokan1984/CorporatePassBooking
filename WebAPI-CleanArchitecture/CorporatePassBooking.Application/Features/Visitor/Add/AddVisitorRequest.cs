using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed record AddVisitorRequest(string Name, string Email, string PhoneNumber) : IRequest<AddVisitorResponse>;
}
