using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORWorkshops
{
    public class Container
    {
        public List<Workshop> Workshops { get; set; }
        public List<Region> Regions { get; set; }
        public List<Workshop> Results { get; set; }

        public Container(List<Workshop> rawWorkshops, List<RawRegion> rawRegions)
        {
            Workshops = rawWorkshops;
            Regions = rawRegions;
        }
    }
}
