using System.Text.Json;
using NORWorkshops;

//Serialize WorkshopsJSON into Workshop class
var workshopPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\verkstedNEW.json";
var workshopJson = File.ReadAllText(workshopPath);
var options = new JsonSerializerOptions();
var workshops = JsonSerializer.Deserialize<Workshop[]>(workshopJson,options);

//Serialize RegionJSON into Region class
var regionNumbersPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\regionsnummer_Norge.json";
var regionNumbersJson = File.ReadAllText(regionNumbersPath);
var optionsRegion = new JsonSerializerOptions();
var regions = JsonSerializer.Deserialize<Region[]>(regionNumbersJson, optionsRegion);

foreach (var region in regions) {region.Show(); Console.WriteLine();}