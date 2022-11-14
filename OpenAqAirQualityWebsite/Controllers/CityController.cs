using Microsoft.AspNetCore.Mvc;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;

namespace OpenAqAirQuality.Website.Controllers
{
    public class CityController : Controller
    {
        private readonly IOpenAqService _openAqService;
        public CityController(IOpenAqService openAqService)
        {
            _openAqService = openAqService;
        }

        //TODO: Implement paging properly adding a proper paging control to front end
        //TODO: Change the routing to not use query string but be more explicit city/{id}
        public async Task<IActionResult> Index(
            string id,
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var locations = await _openAqService.GetLocations(id, pageSize, page);

            var cityViewModel = new CityViewModel(locations);
            return View(cityViewModel);
        }
    }
}
