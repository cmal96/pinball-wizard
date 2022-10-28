using Moq;
using NUnit.Framework;
using PinballWizard.Interfaces;
using PinballWizard.Models;
using PinballWizard.Services;

namespace PinballWizard.Tests
{
    public class RegionServiceTests
    {
        private Mock<IPinballApiClientFactory> mockPinballApiClientFactory;
        private Mock<IPinballApiClient> mockPinballApiClient;
        private IRegionService regionService;

        [SetUp]
        public void Setup()
        {
            mockPinballApiClientFactory = new Mock<IPinballApiClientFactory>();
            mockPinballApiClient = new Mock<IPinballApiClient>();

            mockPinballApiClientFactory.Setup(x => x.Create()).Returns(mockPinballApiClient.Object);

            regionService = new RegionService(mockPinballApiClientFactory.Object);
        }

        [Test]
        public async Task GetRegion_Returns_ValidRegion()
        {
            string latitude = "123";
            string longitude = "456";
            var region = new Region()
            {
                name = "test region",
                lat = latitude,
                lon = longitude
            };

            mockPinballApiClient.Setup(x => x.GetRegionByCoordinates(latitude, longitude, default)).ReturnsAsync(region);

            var result = await regionService.GetRegion(latitude, longitude);

            Assert.That(result, Is.EqualTo(region));
        }
    }
}