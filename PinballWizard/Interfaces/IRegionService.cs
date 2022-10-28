using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface IRegionService
    {
        Task<Region> GetRegion(string latitude, string longitude);
    }
}
