using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Domain.Entities;
using CorporatePassBooking.Persistence.Context;

namespace CorporatePassBooking.Persistence.Repository.Visitor
{
    public class FacilityRepository(CorporatePassBookingContext context) : BaseRepository<Domain.Entities.Facility>(context), IFacilityRepository
    {
        public void Create(Domain.Entities.Visitor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Entities.Visitor entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Visitor>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Visitor> GetByID(Guid visitorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Visitor entity)
        {
            throw new NotImplementedException();
        }

        Task<Booking> IFacilityRepository.GetByID(Guid facilityId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
