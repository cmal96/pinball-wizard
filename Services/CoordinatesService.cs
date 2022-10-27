using Darnton.Blazor.DeviceInterop.Geolocation;
using PinballWizard.Interfaces;
using PinballWizard.Models;

namespace PinballWizard.Services
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly IGeolocationService geolocationService;

        public CoordinatesService(IGeolocationService geolocationService)
        {
            this.geolocationService = geolocationService;
        }

        public async Task<Coordinates> GetCurrentCoordinates()
        {
            var coordinates = new Coordinates();
            try
            {
                var result = await geolocationService.GetCurrentPosition();

                coordinates.lat = result.Position.Coords.Latitude.ToString();
                coordinates.lon = result.Position.Coords.Longitude.ToString();
            }
            catch (Exception)
            {
                throw;
            }

            return coordinates;
        }
    }
}
