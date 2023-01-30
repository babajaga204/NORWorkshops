using System;

namespace NORWorkshops
{
    public class Region
    {
        public string? Name { get; set; }
        public List<PostRange> Ranges { get; set; } = null!;

        public Region(RawRegion region)
        {
            Name = region.AdministrativRegion;
            if (region.Postnumre != null) Ranges = ConvertToRangeList(region.Postnumre);
        }

        private List<PostRange> ConvertToRangeList(string ranges)
        {
            var rangesList = new List<PostRange>();
            if (ranges.Contains(','))
            {
                var rangesStringArr = ranges.Split(',');
                rangesList.AddRange(rangesStringArr
                    .Select(range => range.Split('-'))
                    .Select(rangeValues => new PostRange(Convert.ToInt32(rangeValues[0]), Convert.ToInt32(rangeValues[1]))));
            }
            else
            {
                var rangeValues = ranges.Split('-');
                rangesList.Add(new PostRange(Convert.ToInt32(rangeValues[0]), Convert.ToInt32(rangeValues[1])));
            }
            return rangesList;
        }
        public void Show()
        {
            Console.WriteLine("Navn: " + Name);
            Ranges.ForEach(range =>
            {
                Console.WriteLine("Postnumre: " + range.MinValue + "-" + range.MaxValue);
            });
        }
    }
}