using CorporatePassBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorporatePassBooking.Persistence.Context
{
    public class CorporatePassBookingContext : DbContext
    {
        public CorporatePassBookingContext(DbContextOptions<CorporatePassBookingContext> options) : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

    }
}
