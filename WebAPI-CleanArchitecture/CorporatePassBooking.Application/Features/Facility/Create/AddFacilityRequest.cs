using CorporatePassBooking.Domain.Entities;
using MediatR;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed record AddFacilityRequest(string Name, string Type, int Capacity, string Location, ICollection<string> Amenities) : IRequest<AddFacilityResponse>;

}
