using AutoMapper;
using CorporatePassBooking.Application.Features.Visitor.Add;

namespace CorporatePassBooking.Application.Features
{
    public sealed class AddVisitorMapper : Profile
    {
        public AddVisitorMapper()
        {
            CreateMap<AddVisitorRequest, Domain.Entities.Visitor>();
            CreateMap<Domain.Entities.Visitor, AddVisitorResponse>();
        }
    }
}
