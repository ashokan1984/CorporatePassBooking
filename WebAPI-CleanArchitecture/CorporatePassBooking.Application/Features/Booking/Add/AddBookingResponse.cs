﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Booking.Add
{
    public sealed record class AddBookingResponse
    {
        public Guid ID { get; set; }
    }
}
