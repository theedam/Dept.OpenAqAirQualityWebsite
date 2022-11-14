using System.Text.Json.Serialization;
using OpenAqAirQuality.Models.OpenAq.Shared;

namespace OpenAqAirQuality.Models.OpenAq.Locations
{
    public class Locations
    {
        public Meta? Meta { get; set; }
        
        [JsonPropertyName("results")]
        public List<Location>? LocationItems { get; set; }
    }
}


