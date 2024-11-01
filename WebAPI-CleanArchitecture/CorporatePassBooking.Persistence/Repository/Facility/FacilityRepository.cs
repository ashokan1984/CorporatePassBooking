using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;

namespace CorporatePassBooking.Persistence.Repository.Facility
{
    public class FacilityRepository(CorporatePassBookingContext context) : BaseRepository<Domain.Entities.Facility>(context), IFacilityRepository
    {
    }
}
