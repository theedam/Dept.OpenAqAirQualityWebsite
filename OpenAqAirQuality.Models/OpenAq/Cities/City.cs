namespace OpenAqAirQuality.Models.OpenAq.Cities
{
    public class CityItem
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int Count { get; set; }
        public int Locations { get; set; }
        public DateTime FirstUpdated { get; set; }
        public DateTime LastUpdated { get; set; }


    }
}
