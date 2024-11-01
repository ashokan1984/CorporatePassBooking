using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CorporatePassBookingContext _context;

        public UnitOfWork(CorporatePassBookingContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
