using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Domain.Entities;

namespace CorporatePassBooking.Application.Repository
{
    public interface IFacilityRepository : IBaseRepository<Facility>
    {
        Task<Booking> GetByID(Guid facilityId, CancellationToken cancellationToken);
    }
}
