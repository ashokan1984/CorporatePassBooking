using CorporatePassBooking.Application.Features.Facility.Get.All;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;

namespace CorporatePassBooking.Application.Features.Booking.Get.All
{
    public class GetAllBookingsResponse
    {
        public Guid ID { get; set; } 

        public Guid FacilityId { get; set; }

        public Guid VisitorId { get; set; }

        public int Quantity { get; set; }

        public DateTime BookingDateTime { get; set; }

        public GetAllFacilitiesResponse Facility { get; set; }

        public GetVisitorByIdResponse Visitor { get; set; }


    }
}
