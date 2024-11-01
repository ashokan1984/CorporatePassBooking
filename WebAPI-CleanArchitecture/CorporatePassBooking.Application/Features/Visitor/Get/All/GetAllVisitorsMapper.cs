using AutoMapper;

namespace CorporatePassBooking.Application.Features.Visitor.Get.All
{
    public sealed class GetAllVisitorsMapper : Profile
    {
        public GetAllVisitorsMapper()
        {
            CreateMap<Domain.Entities.Visitor, GetAllVisitorsResponse>();
        }
    }
}
