using OpenAqAirQuality.Common.Constants;
using OpenAqAirQuality.Common.Extensions;
using OpenAqAirQuality.Tests.Unit.Base;

namespace OpenAqAirQuality.Tests.Unit.Extensions
{
    [TestClass]
    public class BooleanExtensionTests : TestBase
    {
        [TestMethod]
        public void ToYesNoString_Success_Nullable_NullValue()
        {
            bool? boolean = null;
            var result = boolean.ToYesNoString();
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ToYesNoString_Success_Nullable_True()
        {
            bool? boolean = true;
            var result = boolean.ToYesNoString();
            Assert.IsNotNull(result);
            Assert.AreEqual(DisplayConstants.Yes, result);
        }

        [TestMethod]
        public void ToYesNoString_Success_Nullable_False()
        {
            bool? boolean = false;
            var result = boolean.ToYesNoString();
            Assert.IsNotNull(result);
            Assert.AreEqual(DisplayConstants.No, result);
        }

        [TestMethod]
        public void ToYesNoString_Success_True()
        {
            bool? boolean = true;
            var result = boolean.ToYesNoString();
            Assert.IsNotNull(result);
            Assert.AreEqual(DisplayConstants.Yes, result);
        }

        [TestMethod]
        public void ToYesNoString_Success_False()
        {
            bool boolean = false;
            var result = boolean.ToYesNoString();
            Assert.IsNotNull(result);
            Assert.AreEqual(DisplayConstants.No, result);
        }
    }
}
