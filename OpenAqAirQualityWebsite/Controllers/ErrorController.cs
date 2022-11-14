using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.ViewModels;

namespace OpenAqAirQuality.Website.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route(RoutingConstants.WebsiteError)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error500()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var requestId = HttpContext.TraceIdentifier;

            var siteException = exceptionHandlerPathFeature?.Error != null 
                ? exceptionHandlerPathFeature.Error 
                : new Exception("An unknown Error occurred");

            _logger.LogError(siteException, "An error occurred with requestId: {RequestId}", requestId);

            var model = new ErrorViewModel
            {
                RequestId = requestId
            };
            return View(model);
        }

        [Route(RoutingConstants.PageNotFound)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
