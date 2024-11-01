using AutoMapper;
using CorporatePassBooking.Application.Features.Booking.Get.ById;
using CorporatePassBooking.Application.Features.Facility.Get.ById;
using CorporatePassBooking.Application.Features.Visitor.Get.ById;
using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Domain.Entities;
using Moq;

namespace CorporatePassBooking_UnitTest
{
    public class UnitTestController
    {
        private readonly Mock<IBookingRepository> bookingRepositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly GetBookingByIdHandler getBookingByIdHandler;

        public UnitTestController() 
        {
            bookingRepositoryMock = new Mock<IBookingRepository>();
            mapperMock = new Mock<IMapper>();
            getBookingByIdHandler = new GetBookingByIdHandler(bookingRepositoryMock.Object, mapperMock.Object);

        }

        [Fact]
        public async Task Handle_ReturnsBooking_WithCorrectDetailsAndNestedResponses()
        {
            // Arrange
            var bookingId = Guid.NewGuid();
            var facilityId = Guid.NewGuid();
            var visitorId = Guid.NewGuid();
            var bookingDateTime = DateTime.UtcNow;

            var amenities = new List<string> { "WiFi", "Parking", "Guided Tours" };

            var booking = new Booking
            {
                ID = bookingId,
                FacilityId = facilityId,
                VisitorId = visitorId,
                Quantity = 5,
                BookingDateTime = bookingDateTime,
                Status = BookingStatusEnum.Confirmed,
                Facility = new Facility { ID = facilityId, Name = "Night Safari" },
                Visitor = new Visitor { ID = visitorId, Name = "Asokan Pandurengan", Email = "Ashokan1984@gmail.com", PhoneNumber = "91418411" }
            };

            var expectedResponse = new GetBookingByIdResponse
            {
                ID = bookingId,
                FacilityId = facilityId,
                VisitorId = visitorId,
                Quantity = 5,
                BookingDateTime = bookingDateTime,
                Facility = new GetFacilityByIdResponse
                {
                    Name = "Night Safari",
                    Type = "Animal Seeing",
                    Capacity = 50,
                    Location = "Singapore",
                    Amenities = amenities
                },
                Visitor = new GetVisitorByIdResponse
                {
                    ID = visitorId,
                    Name = "Asokan Pandurengan",
                    Email = "Ashokan1984@gmail.com",
                    PhoneNumber = "94656931"
                }
            };

            var cancellationToken = new CancellationToken();

            bookingRepositoryMock.Setup(repo => repo.Get(bookingId, cancellationToken))
                                 .ReturnsAsync(booking);

            mapperMock.Setup(m => m.Map<GetBookingByIdResponse>(It.IsAny<Booking>()))
                      .Returns(expectedResponse);

            var request = new GetBookingByIdRequest(bookingId);

            // Act
            var result = await getBookingByIdHandler.Handle(request, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookingId, result.ID);
            Assert.Equal(facilityId, result.FacilityId);
            Assert.Equal(visitorId, result.VisitorId);
            Assert.Equal(5, result.Quantity);
            Assert.Equal(bookingDateTime, result.BookingDateTime);

            // Assertions for Facility properties
            Assert.NotNull(result.Facility);
            Assert.Equal("Night Safari", result.Facility.Name);
            Assert.Equal("Animal Seeing", result.Facility.Type);
            Assert.Equal(50, result.Facility.Capacity);
            Assert.Equal("Singapore", result.Facility.Location);
            Assert.Equal(amenities, result.Facility.Amenities);

            // Assertions for Visitor properties
            Assert.NotNull(result.Visitor);
            Assert.Equal(visitorId, result.Visitor.ID);
            Assert.Equal("AshokRangan", result.Visitor.Name);
            Assert.Equal("ashokan1984@gmail.com", result.Visitor.Email);
            Assert.Equal("+6594656931", result.Visitor.PhoneNumber);
        }
    }
}
