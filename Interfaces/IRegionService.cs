using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface IRegionService
    {
        Region GetRegion(string longitude, string latitude);
    }
}
