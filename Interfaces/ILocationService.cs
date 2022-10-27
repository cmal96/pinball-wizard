using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations(string region);
    }
}
