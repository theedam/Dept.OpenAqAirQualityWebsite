using Moq;
using Moq.Protected;

namespace OpenAqAirQuality.Tests.Unit.Base
{
    public class TestBase
    {
        protected MockRepository Mocks = new(MockBehavior.Strict);
        protected Mock<IHttpClientFactory> _mockHttpClient;

        [TestInitialize]
        public void TestInitialise()
        {
            _mockHttpClient = Mocks.Create<IHttpClientFactory>();
        }

        public Mock<DelegatingHandler> ConfigureHttpClientResponse(HttpResponseMessage apiResponse, Uri requestUrl)
        {
            var clientHandlerMock = new Mock<DelegatingHandler>();
            clientHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(x => x.RequestUri.AbsoluteUri == requestUrl.AbsoluteUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(apiResponse)
                .Verifiable();
            clientHandlerMock.As<IDisposable>().Setup(s => s.Dispose());

            return clientHandlerMock;
        }
    }
}
