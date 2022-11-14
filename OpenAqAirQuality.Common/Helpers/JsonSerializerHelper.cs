using System.Text.Json;

namespace OpenAqAirQuality.Common.Helpers
{
    public static class JsonSerializerHelper
    {
        public static JsonSerializerOptions DefaultOptions = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
    }
}
