namespace OpenAqAirQuality.Models.OpenAq.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMobile { get; set; }
        public bool? IsAnalysis { get; set; }
        public string SensorType { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Measurements { get; set; }
        public List<Parameter>? Parameters { get; set; }
        public List<Source>? Sources { get; set; }
    }
}
