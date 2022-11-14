using Moq;

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
    }
}
