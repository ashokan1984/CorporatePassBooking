namespace CorporatePassBooking.Application.Features.Visitor.Get.ById
{
    public sealed record GetVisitorByIdResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
