namespace OpenAqAirQuality.Models.OpenAq.LatestMeasurements
{
    public class LatestMeasurement
    {
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
