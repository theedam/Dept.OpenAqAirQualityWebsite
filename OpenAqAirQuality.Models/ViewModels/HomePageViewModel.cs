using OpenAqAirQuality.Models.OpenAq.Cities;

namespace OpenAqAirQuality.Models.ViewModels
{
    public class HomePageViewModel
    {
        public readonly Cities? Cities;
        public readonly string Sort;
        public readonly string OrderBy;
        public readonly int Page;
        public readonly int PageSize;
        public readonly int NumberOfPages;
        public HomePageViewModel(Cities? cities, int page, string sort, string orderBy, int pageSize)
        {
            Cities = cities;
            Page = page;
            Sort = sort;
            OrderBy = orderBy;
            PageSize = pageSize;

            NumberOfPages = cities?.Meta?.Found / pageSize ?? 0;
        }
    }
}
