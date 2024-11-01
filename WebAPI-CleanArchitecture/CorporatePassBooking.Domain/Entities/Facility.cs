using CorporatePassBooking.Domain.Common;

namespace CorporatePassBooking.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int TotalCapacity { get; set; }

        public int AvailableCapacity { get; set; }

        public string Location { get; set; }

        public ICollection<Amenity> Amenities { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
