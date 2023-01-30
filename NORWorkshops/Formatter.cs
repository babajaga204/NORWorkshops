using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORWorkshops
{
    public class Formatter
    {
        public List<Workshop> Workshops { get; set; }
        public List<Region> Regions { get; set; }

        public Formatter(List<Workshop> workshops, List<Region> regions)
        {
            Workshops = workshops;
            Regions = regions;
        }
    }
}
