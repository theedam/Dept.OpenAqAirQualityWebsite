using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OpenAqAirQuality.Models.OpenAq.Locations;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;
using OpenAqAirQuality.Tests.Unit.Base;
using OpenAqAirQuality.Website.Controllers;
using OpenAqAirQuality.Models.OpenAq.LatestMeasurements;

namespace OpenAqAirQuality.Tests.Unit.Controllers
{
    [TestClass]
    public class LocationControllerTests : TestBase
    {
        private LocationController _controller;
        private Mock<ILogger<LocationController>> _logger;
        private Mock<IOpenAqService> _openAqService;
        private readonly Location _location = new();
        private LatestMeasurements _latestMeasurements;

        private readonly int _locationId = 123456;
        [TestInitialize]
        public void TestIntialise()
        {
            _logger = Mocks.Create<ILogger<LocationController>>(MockBehavior.Loose);
            _openAqService = Mocks.Create<IOpenAqService>();
            _controller = new LocationController(_openAqService.Object);
            _latestMeasurements = new LatestMeasurements
            {
                LatestMeasurementItems = new List<LatestMeasurement>
                {
                    new()
                }
            };
        }

        [TestMethod]
        public async Task LocationController_Index_Success()
        {
            _openAqService.Setup(x => x.GetLatestMeasurementsByLocationId(_locationId)).ReturnsAsync(_latestMeasurements);
            _openAqService.Setup(x => x.GetLocationById(_locationId)).ReturnsAsync(_location);

            var result = await _controller.Index(_locationId);
            ValidateResult(result);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public async Task LocationController_Index_Failure_NoId()
        {
            await _controller.Index(null);
        }

        private void ValidateResult(IActionResult result)
        {
            Assert.IsNotNull(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as LocationViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(_location, model.Location);
            Assert.AreEqual(_latestMeasurements?.LatestMeasurementItems?.FirstOrDefault(), model.LatestMeasurement);
        }
    }
}
