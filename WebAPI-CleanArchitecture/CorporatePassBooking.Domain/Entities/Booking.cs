using CorporatePassBooking.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporatePassBooking.Domain.Entities
{
    public class Booking : BaseEntity
    {
        [ForeignKey(nameof(Facility))]
        public Guid FacilityId { get; set; }

        [ForeignKey(nameof(Visitor))]
        public Guid VisitorId { get; set; } 

        public int Quantity { get; set; }

        public DateTime BookingDateTime { get; set; }

        public BookingStatusEnum Status { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
