using AutoMapper;

namespace CorporatePassBooking.Application.Features.Visitor.Get.ById
{
    public sealed class GetVisitorByIdMapper : Profile
    {
        public GetVisitorByIdMapper()
        {
            CreateMap<Domain.Entities.Visitor, GetVisitorByIdResponse>();
        }
    }
}
