using CorporatePassBooking.Domain.Common;

namespace CorporatePassBooking.Domain.Entities
{
    public class Visitor : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
