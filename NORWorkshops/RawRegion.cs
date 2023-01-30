using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORWorkshops
{
    public class RawRegion
    {
        public string? AdministrativRegion { get; set; }
        public string? Postnumre { get; set; }

        public RawRegion(){}

        public RawRegion(string region, string postnumre)
        {
            AdministrativRegion = region;
            Postnumre = postnumre;
        }

        public void Show()
        {
            Console.WriteLine($"Fylke: {AdministrativRegion} - Postnumre: {Postnumre}");
        }
    }
}
