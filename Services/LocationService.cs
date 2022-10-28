using PinballWizard.Interfaces;
using PinballWizard.Models;

namespace PinballWizard.Services
{
    public class LocationService : ILocationService
    {
        private readonly IPinballApiClient pinballApiClient;

        public LocationService(IPinballApiClientFactory pinballApiClientFactory)
        {
            pinballApiClient = pinballApiClientFactory.Create();
        }

        public async Task<List<Location>> GetLocations(string region)
        {
            return await pinballApiClient.GetLocationsByRegion(region, default);
        }
    }
}
