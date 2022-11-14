using OpenAqAirQuality.Models.OpenAq.Shared;
using System.Text.Json.Serialization;

namespace OpenAqAirQuality.Models.OpenAq.LatestMeasurements
{
    public class LatestMeasurements
    {
        public Meta? Meta { get; set; }

        [JsonPropertyName("results")]
        public List<LatestMeasurement>? LatestMeasurementItems { get; set; }
    }
}