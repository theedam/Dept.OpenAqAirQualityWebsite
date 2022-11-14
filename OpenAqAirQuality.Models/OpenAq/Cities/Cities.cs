using System.Text.Json.Serialization;
using OpenAqAirQuality.Models.OpenAq.Shared;

namespace OpenAqAirQuality.Models.OpenAq.Cities
{
    public class Cities
    {
        public Meta? Meta { get; set; }

        [JsonPropertyName("results")]
        public List<CityItem>? CityItems { get; set; }
    }
}


