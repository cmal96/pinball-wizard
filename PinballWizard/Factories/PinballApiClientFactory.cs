using PinballWizard.Interfaces;

namespace PinballWizard.Factories
{
    public class PinballApiClientFactory : IPinballApiClientFactory
    {
        private IPinballApiClient pinballApiClient;
        private readonly string host;

        public PinballApiClientFactory(IConfiguration configuration)
        {
            host = configuration["PinballApiUrl"];
        }

        public IPinballApiClient Create()
        {
            if (pinballApiClient != null)
            {
                return pinballApiClient;
            }

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(host)
            };

            pinballApiClient = new PinballApiClient(httpClient);

            return pinballApiClient;
        }
    }
}
