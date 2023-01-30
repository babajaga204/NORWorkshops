

namespace NORWorkshops
{
    public class Container
    {
        public List<Workshop> Workshops { get; set; }
        public List<Region> Regions { get; set; }
        public List<Workshop> SearchResults { get; set; }
        public List<string> Godkjenningstyper { get; private set; }
        public List<string> ValgteGodkjenningstyper { get; set; }

        public Container(List<Workshop> rawWorkshops, List<RawRegion> rawRegions)
        {
            Workshops = rawWorkshops;
            Regions = GetFormattedRegions(rawRegions);
            SearchResults = new List<Workshop>();
            Godkjenningstyper = GetGodkjenningstyper(rawWorkshops);
            ValgteGodkjenningstyper = new List<string>();
        }

        private List<string> GetGodkjenningstyper(List<Workshop> workshops)
        {
            var godkjenningstyper = new List<string>();
            var workshopLicenseHolderList = new List<string>();
            workshops.ForEach(workshop =>
            {
                workshopLicenseHolderList = workshop.GetGodkjenningstyper();
                workshopLicenseHolderList.ForEach(item =>
                {
                    if (!godkjenningstyper.Contains(item))
                    {
                        godkjenningstyper.Add(item);
                    }
                });

            });
            return godkjenningstyper;
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
                region.Show();
            });
        }

        public void ShowRegionNamesForCommand()
        {
            var command = 1;
            foreach (var region in Regions)
            {
                Console.WriteLine($"{command} - {region.Name}");
                command++;
            }
        }

        public void SetSearchResults(int fylkesIndex)
        {
            SearchResults = new List<Workshop>();
            var paramRegion = Regions[fylkesIndex - 1];
            paramRegion.Ranges.ForEach(range =>
            {
                Workshops.ForEach(
                    workshop =>
                    {
                        if (range.CheckIfInRange(workshop.GetPostnummer()))
                        {
                            SearchResults.Add(workshop);
                        }
                    });
            });
        }

        public (int, string) IsNumCheck(List<T> list)
        {
            var inputStr = Console.ReadLine();
            var isNum = int.TryParse(inputStr, out var num);
            while (!isNum || !IsNumValid(list, num))
            {
                Console.WriteLine("Vennligst tast inn et gyldig tall");
                IsNumCheck(list);
            }
            return (num, inputStr);
        }

        private bool IsNumValid<T>(List<T> list, int inputNum)
        {
            return inputNum < 0 && inputNum < list.Count;
        }
    }
}
