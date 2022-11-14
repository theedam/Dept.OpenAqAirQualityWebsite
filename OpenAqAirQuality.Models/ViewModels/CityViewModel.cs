using OpenAqAirQuality.Models.OpenAq.Locations;

namespace OpenAqAirQuality.Models.ViewModels
{
    public class CityViewModel
    {
        public readonly Locations? Locations;

        public CityViewModel(Locations? locations)
        {
            Locations = locations;
        }
    }
}
