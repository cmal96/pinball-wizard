using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(string region);
    }
}
