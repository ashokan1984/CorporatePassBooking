using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Update
{
    public sealed record class UpdateBookingResponse
    {
        public Guid ID { get; set; }
    }
}
