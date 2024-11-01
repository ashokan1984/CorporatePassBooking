namespace CorporatePassBooking.Application.Features.Visitor.Get.All
{
    public sealed record GetAllVisitorsResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
