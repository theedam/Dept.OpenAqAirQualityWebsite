using Microsoft.Extensions.Logging;
using Moq;
using OpenAqAirQuality.Services.OpenAq;
using OpenAqAirQuality.Tests.Unit.Base;
using System.Net;
using static OpenAqAirQuality.Common.Constants.ConfigurationConstants;
using OpenAqAirQuality.Common.Constants;

namespace OpenAqAirQuality.Tests.Unit.Services
{
    [TestClass]
    public class OpenAqServiceTests : TestBase
    {
        private OpenAqService _openAqService;
        private Mock<ILogger<OpenAqService>> _logger;
        private Mock<IHttpClientFactory> _httpClientFactory;
        private readonly string _baseAddress = "https://api.com/";

        [TestInitialize]
        public void TestIntialise()
        {
            _httpClientFactory = Mocks.Create<IHttpClientFactory>();
            _logger = Mocks.Create<ILogger<OpenAqService>>();
            _openAqService = new OpenAqService(_httpClientFactory.Object, _logger.Object);
        }

        [TestMethod]
        public async Task GetLatestMeasurementsByLocationId_Success()
        {
            var locationId = 1234;
            var url = $"{_baseAddress}latest/{locationId}";
            MockHttpRequest(url, OpenAqJsonOutputs.LatestMeasurements);

            var result = await _openAqService.GetLatestMeasurementsByLocationId(locationId);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Meta);
            Assert.AreEqual("api.openaq.org", result.Meta.Website);
            Assert.IsNotNull(result.LatestMeasurementItems);
            Assert.IsNotNull(result.LatestMeasurementItems.FirstOrDefault());
            Assert.AreEqual("10920 Canyon RD", result.LatestMeasurementItems.FirstOrDefault().Location);
        }

        [TestMethod]
        public async Task GetCities_Success()
        {
            var pageSize = OpenAqConstants.DefaultPageSize;
            var page = OpenAqConstants.DefaultPage;
            var sort = OpenAqConstants.SortAsc;
            var orderBy = OpenAqConstants.OrderByCity;

            var url = $"{_baseAddress}cities?limit={pageSize}&page={page}&sort={sort}&order_by={orderBy}";
            MockHttpRequest(url, OpenAqJsonOutputs.Cities);

            var result = await _openAqService.GetCities(pageSize, page, sort, orderBy);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Meta);
            Assert.AreEqual("api.openaq.org", result.Meta.Website);
            Assert.IsNotNull(result.CityItems);
            Assert.IsNotNull(result.CityItems.FirstOrDefault());
            Assert.AreEqual("007", result.CityItems.FirstOrDefault().City);
        }

        [TestMethod]
        public async Task GetLocationById_Success()
        {
            var locationId = 1234;
            var url = $"{_baseAddress}locations/{locationId}";
            MockHttpRequest(url, OpenAqJsonOutputs.Location);

            var result = await _openAqService.GetLocationById(locationId);
            Assert.IsNotNull(result);
            Assert.AreEqual("10920 Canyon RD", result.Name);
        }

        [TestMethod]
        public async Task GetLocations_Success()
        {
            var pageSize = OpenAqConstants.DefaultPageSize;
            var page = OpenAqConstants.DefaultPage;
            var city = "London";

            var url = $"{_baseAddress}locations?limit={pageSize}&page={page}&city={city}";
            MockHttpRequest(url, OpenAqJsonOutputs.Location);

            var result = await _openAqService.GetLocations(city, pageSize, page);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Meta);
            Assert.AreEqual("api.openaq.org", result.Meta.Website);
            Assert.IsNotNull(result.LocationItems);
            Assert.IsNotNull(result.LocationItems.FirstOrDefault());
            Assert.AreEqual("10920 Canyon RD", result.LocationItems.FirstOrDefault().Name);
        }

        private void MockHttpRequest(string url, string content)
        {
            var apiResponse = new HttpResponseMessage(HttpStatusCode.OK);

            apiResponse.Content = new StringContent(content);

            var requestUrl = new Uri(url);

            var httpClientMockHandler = ConfigureHttpClientResponse(apiResponse, requestUrl);
            var httpClient = new HttpClient(httpClientMockHandler.Object);
            httpClient.BaseAddress = new Uri(_baseAddress);

            _httpClientFactory.Setup(x => x.CreateClient(OpenAq.HttpClient))
                .Returns(httpClient);
        }
    }
}
