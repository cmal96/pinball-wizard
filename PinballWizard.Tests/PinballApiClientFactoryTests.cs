using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using PinballWizard.Factories;
using PinballWizard.Interfaces;

namespace PinballWizard.Tests
{
    public class PinballApiClientFactoryTests
    {
        private IPinballApiClientFactory pinballApiClientFactory;
        private Mock<IConfiguration> mockConfiguration;

        [SetUp]
        public void Setup()
        {
            mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["PinballApiUrl"]).Returns("https://test.url/");
            pinballApiClientFactory = new PinballApiClientFactory(mockConfiguration.Object);
        }

        [Test]
        public void Create_Returns_ValidApiClient()
        {
            var result = pinballApiClientFactory.Create();

            Assert.That(result, Is.Not.Null);
        }
    }
}
