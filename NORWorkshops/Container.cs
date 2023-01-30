

namespace NORWorkshops
{
    public class Container
    {
        public List<Workshop> Workshops { get; set; }
        public List<Region> Regions { get; set; }
        public List<Workshop> SearchResults { get; set; }

        public Container(List<Workshop> rawWorkshops, List<RawRegion> rawRegions)
        {
            Workshops = rawWorkshops;
            Regions = GetFormattedRegions(rawRegions);
            SearchResults = new List<Workshop>();
        }
        private List<Region> GetFormattedRegions(List<RawRegion> rawRegions)
        {
            var formattedRegions = new List<Region>();
            rawRegions.ForEach(rawRegion => formattedRegions.Add(new Region(rawRegion)));
            return formattedRegions;
        }

        public void ShowAllWorkshops()
        {
            Workshops.ForEach(workshop =>
            {
                workshop.Show();
            });
        }

        public void ShowSearchResult()
        {
            SearchResults.ForEach(workshop =>
            {
                workshop.Show();
            });
        }

        public void ShowAllRegions()
        {
            Regions.ForEach(region =>
            {
                Console.WriteLine(region.Name);
                region.Ranges.ForEach(range =>
                {
                    range.Show();
                });
            });
        }
    }
}
