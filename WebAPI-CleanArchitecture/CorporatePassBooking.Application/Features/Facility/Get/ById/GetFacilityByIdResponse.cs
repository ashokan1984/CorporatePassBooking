namespace CorporatePassBooking.Application.Features.Facility.Get.ById
{
    public sealed record GetFacilityByIdResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public ICollection<string> Amenities { get; set; }

    }
}
