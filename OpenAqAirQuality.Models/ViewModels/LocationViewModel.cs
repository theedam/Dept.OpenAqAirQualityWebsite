using OpenAqAirQuality.Models.OpenAq.LatestMeasurements;
using OpenAqAirQuality.Models.OpenAq.Locations;

namespace OpenAqAirQuality.Models.ViewModels
{
    public class LocationViewModel
    {
        public readonly LatestMeasurement? LatestMeasurement;
        public readonly Location? Location;

        public LocationViewModel(LatestMeasurement? latestMeasurement, Location? location)
        {
            LatestMeasurement = latestMeasurement;
            Location = location;
        }
    }
}
