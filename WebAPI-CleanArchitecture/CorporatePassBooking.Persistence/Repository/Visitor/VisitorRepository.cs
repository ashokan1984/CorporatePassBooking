using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CorporatePassBooking.Persistence.Repository.Visitor
{
    public class VisitorRepository(CorporatePassBookingContext context) : BaseRepository<Domain.Entities.Visitor>(context), IVisitorRepository
    {
    }
}
