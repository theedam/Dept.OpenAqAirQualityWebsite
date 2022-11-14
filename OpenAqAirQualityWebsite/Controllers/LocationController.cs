using Microsoft.AspNetCore.Mvc;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;

namespace OpenAqAirQuality.Website.Controllers
{
    public class LocationController : Controller
    {
        private readonly IOpenAqService _openAqService;
        public LocationController(IOpenAqService openAqService)
        {
            _openAqService = openAqService;
        }

        //TODO: Change the routing to not use query string but be more explicit location/{id}
        public async Task<IActionResult> Index(
            int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var latestMeasurements = await _openAqService.GetLatestMeasurementsByLocationId(id.Value);
            var location = await _openAqService.GetLocationById(id.Value);

            var locationViewModel = new LocationViewModel(latestMeasurements?.LatestMeasurementItems?.FirstOrDefault(), location);
            return View(locationViewModel);
        }
    }
}
