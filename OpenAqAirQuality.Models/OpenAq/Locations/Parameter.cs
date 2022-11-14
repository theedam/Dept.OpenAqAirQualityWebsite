using System.Text.Json.Serialization;

namespace OpenAqAirQuality.Models.OpenAq.Locations
{
    public class Parameter
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
        public float Average { get; set; }
        public float LastValue { get; set; }
        [JsonPropertyName("Parameter")]
        public string ParameterName { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ParameterId { get; set; }
        public DateTime FirstUpdated { get; set; }
    }
}
