using System.Text.Json;
using NORWorkshops;

//Serialize WorkshopsJSON into Workshop class
var workshopPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\verkstedNEW.json";
var workshopJson = File.ReadAllText(workshopPath);
var options = new JsonSerializerOptions();
List<Workshop> workshops = JsonSerializer.Deserialize<Workshop[]>(workshopJson,options).ToList();

//Serialize RegionJSON into RawRegion class
var regionNumbersPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\regionsnummer_Norge.json";
var regionNumbersJson = File.ReadAllText(regionNumbersPath);
var optionsRegion = new JsonSerializerOptions();
List<RawRegion> regions = JsonSerializer.Deserialize<RawRegion[]>(regionNumbersJson, optionsRegion).ToList();

var container = new Container(workshops, regions);
container.ShowAllWorkshops();