﻿

using System.ComponentModel.Design.Serialization;

namespace NORWorkshops
{
    public class WorkshopApp
    {
        public List<Workshop> Workshops { get; set; }
        public List<Region> Regions { get; set; }
        public List<Workshop> SearchResults { get; set; }
        public List<string> Godkjenningstyper { get; private set; }
        public List<string> ValgteGodkjenningstyper { get; set; }
        public WorkshopApp(List<Workshop> rawWorkshops, List<RawRegion> rawRegions)
        {
            Workshops = rawWorkshops;
            Regions = GetFormattedRegions(rawRegions);
            SearchResults = new List<Workshop>();
            Godkjenningstyper = GetGodkjenningstyper(rawWorkshops);
            ValgteGodkjenningstyper = new List<string>();
            FormatAllWorkshopGodkjenningstyper();
            Godkjenningstyper.ForEach(x => { ValgteGodkjenningstyper.Add(string.Empty); });
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
        public void Run()
        {
            while (true)
            {
                ShowRegionNamesForCommand();
                SetSearchResults(input);
                ShowGodkjenningstyperForCommand();
                var inputStr2 = Console.ReadLine();
                var input2 = Convert.ToInt32(inputStr2);
                SetValgteGodkjenningstyper(input2);
                break;
            }
        }

        private void SetValgteGodkjenningstyper(int input)
        {
            ValgteGodkjenningstyper[input-1] = Godkjenningstyper[input-1];
        }

        private void ShowGodkjenningstyperForCommand()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tast inn nummeret som representerer godkjenningstypen du vil ha med i søket.");
                Console.WriteLine("Søkemotoren vil ta med alle verksted som har en eller fler av godkjenningstypene");
                Console.WriteLine();
                var command = 1;
                foreach (var type in Godkjenningstyper)
                {
                    Console.WriteLine($"{command.ToString(),-2} - {type} {CheckEmptyAndShowValue(command),50}");
                    command++;
                }
                Console.WriteLine();
                var inputStr = Console.ReadLine();
                var input = Convert.ToInt32(inputStr);
                if (inputStr != null && IsNum(inputStr) && IsNumValid(Godkjenningstyper, input)) continue;
                Console.WriteLine("Vennligst tast inn et gyldig tall");
                Thread.Sleep(3000);
                break;
            }
        }

        private string CheckEmptyAndShowValue(int command)
        {
            return ValgteGodkjenningstyper[command - 1] == string.Empty ? "" : ValgteGodkjenningstyper[command - 1];
        }

        public void ShowRegionNamesForCommand()
        {
           while (true) 
           {
                Console.Clear();
                Console.WriteLine("Tast inn nummeret som representerer fylket du vil søke i.");
                Console.WriteLine();
                var command = 1;
                foreach (var region in Regions)
                {
                    Console.WriteLine($"{command.ToString(),-2} - {region.Name} ({GetCount(region.Ranges)})");
                    command++;
                }

                Console.WriteLine();
                var inputStr = Console.ReadLine();
                var input = Convert.ToInt32(inputStr);
                if (inputStr != null && IsNum(inputStr) && IsNumValid(Regions, input)) return;
                Console.WriteLine("Vennligst tast inn et gyldig tall");
                Thread.Sleep(3000);
                break;
           }
        }
        private int GetCount(List<PostRange> regionRanges)
        {
            return regionRanges
                .Sum(range => Workshops
                .Count(workshop => workshop.GetPostnummer() >= range.MinValue && workshop.GetPostnummer() <= range.MaxValue));
        }
        public void SetSearchResults(int fylkesIndex)
        {
            SearchResults = new List<Workshop>(); // Pass på å fjerne!!!
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
        private bool IsNum(string input)
        {
            return int.TryParse(input, out _);
        }
        private bool IsNumValid<T>(List<T> list, int input)
        {
            return input > 0 && input <= list.Count;
        }
        public void ShowAllWorkshops()
        {
            Workshops.ForEach(workshop => { workshop.Show(); });
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
        private void FormatAllWorkshopGodkjenningstyper()
        {
            foreach (var workshop in Workshops) workshop.FormatGodkjenningstyper();
        }
    }
}
