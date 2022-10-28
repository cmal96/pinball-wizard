namespace PinballWizard.Models
{
    public class Region : Coordinates
    {
        public string name { get; set; }
    }

    public class RootRegion
    {
        public Region region { get; set; }
    }
}
