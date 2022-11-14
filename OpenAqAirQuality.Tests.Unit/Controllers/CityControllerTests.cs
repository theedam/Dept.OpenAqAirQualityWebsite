using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.OpenAq.Locations;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;
using OpenAqAirQuality.Tests.Unit.Base;
using OpenAqAirQuality.Website.Controllers;

namespace OpenAqAirQuality.Tests.Unit.Controllers
{
    [TestClass]
    public class CityControllerTests : TestBase
    {
        private CityController _controller;
        private Mock<ILogger<CityController>> _logger;
        private Mock<IOpenAqService> _openAqService;
        private readonly Locations _locations = new();

        [TestInitialize]
        public void TestIntialise()
        {
            _openAqService = Mocks.Create<IOpenAqService>();
            _controller = new CityController(_openAqService.Object);
        }

        [TestMethod]
        public async Task CityController_Index_Success()
        {
            var cityId = "city1234";

            _openAqService.Setup(x =>
                    x.GetLocations(cityId, OpenAqConstants.DefaultPageSize, OpenAqConstants.DefaultPage))
                .ReturnsAsync(_locations);

            var result = await _controller.Index(cityId);
            ValidateResult(result);
        }

        [TestMethod]
        public async Task CityController_Index_Success_AllParameters()
        {
            var cityId = "city1234";
            var pageSize = 50;
            var page = 4;
            _openAqService.Setup(x =>
                    x.GetLocations(cityId, pageSize, page))
                .ReturnsAsync(_locations);

            var result = await _controller.Index(cityId, pageSize, page);
            ValidateResult(result);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public async Task CityController_Index_Failure_NoId()
        {
            await _controller.Index(null);
        }

        private void ValidateResult(IActionResult result)
        {
            Assert.IsNotNull(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as CityViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(_locations, model.Locations);
        }
    }
}
