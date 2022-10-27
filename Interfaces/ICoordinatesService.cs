using PinballWizard.Models;

namespace PinballWizard.Interfaces
{
    public interface ICoordinatesService
    {
        Task<Coordinates> GetCurrentCoordinates();
    }
}
