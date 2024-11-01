using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CorporatePassBooking.Persistence.Repository.Visitor
{
    public class BookingRepository(CorporatePassBookingContext context) : BaseRepository<Domain.Entities.Booking>(context), IBookingRepository
    {
        public async override Task<Domain.Entities.Booking> Get(Guid id, CancellationToken cancellationToken)
        {
            var booking = await Context.Bookings
                .Include(i => i.Facility)
                .Include(i => i.Visitor)
                .FirstOrDefaultAsync(x => x.ID == id);
            return booking;
        }

        public Task<List<CorporatePassBooking.Domain.Entities.Visitor>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CorporatePassBooking.Domain.Entities.Visitor> GetByID(Guid visitorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(CorporatePassBooking.Domain.Entities.Visitor entity)
        {
            throw new NotImplementedException();
        }
    }
}
