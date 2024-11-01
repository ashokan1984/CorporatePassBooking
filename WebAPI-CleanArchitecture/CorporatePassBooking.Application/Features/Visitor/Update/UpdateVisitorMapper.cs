using AutoMapper;

namespace CorporatePassBooking.Application.Features.Visitor.Update
{
    public sealed class UpdateVisitorMapper : Profile
    {
        public UpdateVisitorMapper()
        {
            CreateMap<UpdateVisitorRequest, Domain.Entities.Visitor>();
            CreateMap<Domain.Entities.Visitor, UpdateVisitorResponse>();
        }
    }
}
