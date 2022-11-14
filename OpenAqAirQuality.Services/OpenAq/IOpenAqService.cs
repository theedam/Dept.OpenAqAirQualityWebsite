using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.OpenAq.Cities;
using OpenAqAirQuality.Models.OpenAq.LatestMeasurements;
using OpenAqAirQuality.Models.OpenAq.Locations;

namespace OpenAqAirQuality.Services.OpenAq
{
    public interface IOpenAqService
    {
        Task<LatestMeasurements?> GetLatestMeasurementsByLocationId(
            int locationId);

        Task<Cities?> GetCities(
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage,
            string sort = OpenAqConstants.SortAsc,
            string orderBy = OpenAqConstants.OrderByCity);

        Task<Locations?> GetLocations(
            string? city = null,
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage);

        Task<Location?> GetLocationById(
            int locationId);
    }
}
