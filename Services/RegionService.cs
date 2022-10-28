using PinballWizard.Interfaces;
using PinballWizard.Models;

namespace PinballWizard.Services
{
    public class RegionService : IRegionService
    {
        private readonly IPinballApiClient pinballApiClient;

        public RegionService(IPinballApiClientFactory pinballApiClientFactory)
        {
            this.pinballApiClient = pinballApiClientFactory.Create();
        }

        public async Task<Region> GetRegion(string latitude, string longitude)
        {
            return await pinballApiClient.GetRegionByCoordinates(latitude, longitude, default);
        }
    }
}
