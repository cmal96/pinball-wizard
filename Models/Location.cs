namespace PinballWizard.Models
{
    public class Location : Coordinates
    {
        public string name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    public class RootLocation
    {
        public List<Location> locations { get; set; }
    }
}