using Microsoft.AspNetCore.Mvc;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;

namespace OpenAqAirQuality.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOpenAqService _openAqService;
        public HomeController(IOpenAqService openAqService)
        {
            _openAqService = openAqService;
        }

        //TODO: Implement paging properly adding a proper paging control to front end
        public async Task<IActionResult> Index(
            int pageSize = OpenAqConstants.DefaultPageSize,
            int page = OpenAqConstants.DefaultPage,
            string sort = OpenAqConstants.SortAsc,
            string orderBy = OpenAqConstants.OrderByCity)
        {
            var cities = await _openAqService.GetCities(pageSize, page, sort, orderBy);

            var homePageViewModel = new HomePageViewModel(cities, page, sort, orderBy, pageSize);
            return View(homePageViewModel);
        }
    }
}