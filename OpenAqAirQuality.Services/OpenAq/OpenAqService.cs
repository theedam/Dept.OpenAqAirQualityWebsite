using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Common.Helpers;
using OpenAqAirQuality.Models.OpenAq.Cities;
using OpenAqAirQuality.Models.OpenAq.LatestMeasurements;
using OpenAqAirQuality.Models.OpenAq.Locations;

namespace OpenAqAirQuality.Services.OpenAq
{
    public class OpenAqService : IOpenAqService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OpenAqService> _logger;

        public OpenAqService(IHttpClientFactory httpClientFactory, ILogger<OpenAqService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<LatestMeasurements?> GetLatestMeasurementsByLocationId(int locationId)
        {
            var apiResponse = await GetApiResponse($"latest/{locationId}");
            var latestMeasurements = JsonSerializer.Deserialize<LatestMeasurements>(apiResponse, JsonSerializerHelper.DefaultOptions);
            return latestMeasurements;
        }

        public async Task<Cities?> GetCities(
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage,
            string sort = OpenAqConstants.SortAsc,
            string orderBy = OpenAqConstants.OrderByCity)
        {
            var apiResponse = await GetApiResponse($"cities?limit={pageSize}&page={page}&sort={sort}&order_by={orderBy}");
            var cities = JsonSerializer.Deserialize<Cities>(apiResponse, JsonSerializerHelper.DefaultOptions);
            return cities;
        }

        public async Task<Location?> GetLocationById(
            int locationId)
        {
            var url = new StringBuilder($"locations/{locationId}");
            var apiResponse = await GetApiResponse(url.ToString());
            var locations = JsonSerializer.Deserialize<Locations>(apiResponse, JsonSerializerHelper.DefaultOptions);
            return locations?.LocationItems?.FirstOrDefault();
        }

        public async Task<Locations?> GetLocations(
            string? city = null,
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage)
        {
            var url = new StringBuilder($"locations?limit={pageSize}&page={page}");
            if (!string.IsNullOrWhiteSpace(city))
            {
                url.Append($"&city={city}");
            }
            var apiResponse = await GetApiResponse(url.ToString());
            var locations = JsonSerializer.Deserialize<Locations>(apiResponse, JsonSerializerHelper.DefaultOptions);
            return locations;
        }

        private async Task<string> GetApiResponse(string url)
        {
            using var httpClient = _httpClientFactory.CreateClient(ConfigurationConstants.OpenAq.HttpClient);

            using var response =
                await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return apiResponse;
            }

            _logger.LogError("Error on Getting Api Response. Url:{url}, Response Code: {response.StatusCode}, Content:{apiResponse}",
                url, response.StatusCode, apiResponse);
            throw new HttpRequestException(apiResponse);
        }

    }
}
