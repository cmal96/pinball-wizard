using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface IPinballApiClient
    {
        Task<Region> GetRegionByCoordinates(string latitude, string longitude, CancellationToken cancellationToken);
        Task<List<Location>> GetLocationsByRegion(string region, CancellationToken cancellationToken);
    }
}
