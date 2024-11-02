namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed record GetFacilityByIdResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TotalCapacity { get; set; }
        public string Location { get; set; }

        public ICollection<string> Amenities { get; set; }

    }
}
