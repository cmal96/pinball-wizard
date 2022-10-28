using PinballWizard.Interfaces;
using PinballWizard.Models;

namespace PinballWizard.Factories
{
    public class PinballApiClient : IPinballApiClient
    {
        private readonly HttpClient httpClient;
        private const string RegionAPIPath = "regions/closest_by_lat_lon.json";
        private const string LocationAPIPath = "region/{0}/locations.json";

        public PinballApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Region> GetRegionByCoordinates(string latitude, string longitude, CancellationToken cancellationToken)
        {
            Region region = new Region();
            var path = $"{RegionAPIPath}?lat={latitude}&lon={longitude}";

            var response = await this.httpClient.GetAsync(path, cancellationToken);
            response.EnsureSuccessStatusCode();

            var regionToString = await response.Content.ReadAsStringAsync();
            region = (await response.Content.ReadFromJsonAsync<RootRegion>()).region;

            return region;
        }

        public async Task<List<Location>> GetLocationsByRegion(string region, CancellationToken cancellationToken)
        {
            List<Location> locations;
            var path = string.Format(LocationAPIPath, region);

            var response = await this.httpClient.GetAsync(path, cancellationToken);
            response.EnsureSuccessStatusCode();

            var locationsToString = await response.Content.ReadAsStringAsync();
            locations = (await response.Content.ReadFromJsonAsync<RootLocation>()).locations;

            return locations;
        }
    }
}
