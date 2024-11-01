using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CorporatePassBooking.Persistence.Repository.Visitor
{
    public class BookingRepository(CorporatePassBookingContext context) : BaseRepository<Domain.Entities.Booking>(context), IBookingRepository
    {
    }
}
