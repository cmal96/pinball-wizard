using Darnton.Blazor.DeviceInterop.Geolocation;
using Moq;
using NUnit.Framework;
using PinballWizard.Interfaces;
using PinballWizard.Services;

namespace PinballWizard.Tests
{

    public class CoordinatesServiceTests
    {
        private Mock<IGeolocationService> mockGeolocationService;
        private ICoordinatesService coordinatesService;

        [SetUp]
        public void Setup()
        {
            mockGeolocationService = new Mock<IGeolocationService>();
            coordinatesService = new CoordinatesService(mockGeolocationService.Object);
        }

        [Test]
        public async Task GetCurrentCoordinates_Returns_ValidCoordinates()
        {
            var geolocationResult = new GeolocationResult()
            {
                Position = new GeolocationPosition()
                {
                    Coords = new GeolocationCoordinates
                    {
                        Latitude = 0.0,
                        Longitude = 0.0
                    }
                }
            };

            mockGeolocationService.Setup(x => x.GetCurrentPosition(null)).ReturnsAsync(geolocationResult);

            var coordinates = await coordinatesService.GetCurrentCoordinates();

            Assert.That(coordinates.lat, Is.EqualTo(geolocationResult.Position.Coords.Latitude.ToString()));
            Assert.That(coordinates.lat, Is.EqualTo(geolocationResult.Position.Coords.Longitude.ToString()));
        }
    }
}
