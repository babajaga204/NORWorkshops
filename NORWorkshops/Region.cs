using System;

namespace NORWorkshops
{
    public class Region
    {
        public string Name { get; set; }
        public List<PostRange> Ranges { get; set; }

        public Region(RawRegion region)
        {
            Name = region.AdministrativRegion;
            Ranges = ConvertToRangeList(region.Postnumre);
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
    }
}