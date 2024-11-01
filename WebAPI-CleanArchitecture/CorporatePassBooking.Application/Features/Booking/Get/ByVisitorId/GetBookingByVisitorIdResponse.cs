using CorporatePassBooking.Application.Features.Facility.Get.ById;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Get.ByVisitorId
{
    public class GetBookingByVisitorIdResponse
    {
        public Guid ID { get; set; }

        public Guid FacilityId { get; set; }

        public Guid VisitorId { get; set; }

        public int Quantity { get; set; }

        public DateTime BookingDateTime { get; set; }

        public GetFacilityByIdResponse Facility { get; set; }

        public GetVisitorByIdResponse Visitor { get; set; }
    }
}
