using System.Text.Json;
using NORWorkshops;

//Serialize WorkshopsJSON into RawWorkshop class
var workshopPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\verkstedNEW.json";
var workshopJson = File.ReadAllText(workshopPath);
var options = new JsonSerializerOptions();
var workshops = JsonSerializer.Deserialize<RawWorkshop[]>(workshopJson,options);

//Serialize RegionJSON into RawRegion class
var regionNumbersPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\regionsnummer_Norge.json";
var regionNumbersJson = File.ReadAllText(regionNumbersPath);
var optionsRegion = new JsonSerializerOptions();
var regions = JsonSerializer.Deserialize<RawRegion[]>(regionNumbersJson, optionsRegion);

foreach (var region in regions) {region.Show(); Console.WriteLine();}