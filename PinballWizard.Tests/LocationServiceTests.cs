using Moq;
using NUnit.Framework;
using PinballWizard.Interfaces;
using PinballWizard.Models;
using PinballWizard.Services;

namespace PinballWizard.Tests
{
    public class LocationServiceTests
    {
        private Mock<IPinballApiClientFactory> mockPinballApiClientFactory;
        private Mock<IPinballApiClient> mockPinballApiClient;
        private ILocationService locationService;

        [SetUp]
        public void Setup()
        {
            mockPinballApiClientFactory = new Mock<IPinballApiClientFactory>();
            mockPinballApiClient = new Mock<IPinballApiClient>();

            mockPinballApiClientFactory.Setup(x => x.Create()).Returns(mockPinballApiClient.Object);

            locationService = new LocationService(mockPinballApiClientFactory.Object);
        }

        [Test]
        public async Task GetLocations_Returns_ValidLocations()
        {
            string region = "test";
            var locations = new List<Location>();

            locations.Add(new Location()
            {
                name = "test location"
            });

            mockPinballApiClient.Setup(x => x.GetLocationsByRegion(region, default)).ReturnsAsync(locations);

            var result = await locationService.GetLocations(region);

            Assert.That(result, Is.EqualTo(locations));
        }
    }
}