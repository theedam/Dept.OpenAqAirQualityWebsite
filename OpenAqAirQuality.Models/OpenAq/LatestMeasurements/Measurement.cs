namespace OpenAqAirQuality.Models.OpenAq.LatestMeasurements
{
    public class Measurement
    {
        public string Parameter { get; set; }
        public float Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Unit { get; set; }
    }
}
