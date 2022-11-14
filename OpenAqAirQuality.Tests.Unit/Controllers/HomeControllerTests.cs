using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Models.OpenAq.Cities;
using OpenAqAirQuality.Models.ViewModels;
using OpenAqAirQuality.Services.OpenAq;
using OpenAqAirQuality.Tests.Unit.Base;
using OpenAqAirQuality.Website.Controllers;

namespace OpenAqAirQuality.Tests.Unit.Controllers
{
    [TestClass]
    public class HomeControllerTests : TestBase
    {
        private HomeController _controller;
        private Mock<ILogger<HomeController>> _logger;
        private Mock<IOpenAqService> _openAqService;
        private Cities _cities = new();

        [TestInitialize]
        public void TestIntialise()
        {
            _openAqService = Mocks.Create<IOpenAqService>();
            _controller = new HomeController(_openAqService.Object);
        }

        [TestMethod]
        public async Task HomePageController_Index_Success_NoParameters()
        {
            _openAqService.Setup(x => x.GetCities(OpenAqConstants.DefaultPageSize, OpenAqConstants.DefaultPage,
                OpenAqConstants.SortAsc, OpenAqConstants.OrderByCity)).ReturnsAsync(_cities);

            var result = await _controller.Index();
            ValidateResult(result);
        }

        private void ValidateResult(IActionResult result)
        {
            Assert.IsNotNull(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as HomePageViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(_cities, model.Cities);
        }

        [TestMethod]
        public async Task HomePageController_Index_Success_AllParameters()
        {
            var pageSize = 697;
            var page = 12;
            var sort = OpenAqConstants.SortDesc;
            var orderBy = OpenAqConstants.OrderByCountry;

            _openAqService.Setup(x => x.GetCities(pageSize, page,
                sort, orderBy)).ReturnsAsync(_cities);

            var result = await _controller.Index(697, page, sort, orderBy);
            ValidateResult(result);
        }
    }
}
