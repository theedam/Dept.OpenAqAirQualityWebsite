using OpenAqAirQuality.Common.Constants;

namespace OpenAqAirQuality.Common.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value)
        {
            return value ? DisplayConstants.Yes : DisplayConstants.No;
        }

        public static string ToYesNoString(this bool? value)
        {
            return value.HasValue ? value.Value.ToYesNoString() : string.Empty;
        }
    }
}
