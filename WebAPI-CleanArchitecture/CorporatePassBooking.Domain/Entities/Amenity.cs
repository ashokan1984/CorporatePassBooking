using CorporatePassBooking.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporatePassBooking.Domain.Entities
{
    public class Amenity : BaseEntity
    {
        [ForeignKey(nameof(Facility))]
        public Guid FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public string Name { get; set; }
    }
}
