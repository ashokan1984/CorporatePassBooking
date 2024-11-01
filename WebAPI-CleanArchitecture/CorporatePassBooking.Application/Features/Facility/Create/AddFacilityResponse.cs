using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporatePassBooking.Application.Features.Visitor.Add
{
    public sealed record class AddFacilityResponse
    {
        public Guid ID { get; set; }
    }
}
