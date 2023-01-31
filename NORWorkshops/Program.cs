using System.Collections.Specialized;
using System.Text.Json;
using NORWorkshops;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var workshops = ReadWorkshopsFromJson(out var s, out var workshopJson1);
var regions = ReadRegionsFromJson(out var regionNumbersPath1, out var regionNumbersJson1);
var app = new WorkshopApp(workshops, regions);

while (true)
{
    app.Run();
    Console.ReadLine();
}

List<RawRegion> ReadRegionsFromJson(out string regionNumbersPath, out string regionNumbersJson)
{
    //Serialize RegionJSON into RawRegion class
    regionNumbersPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\regionsnummer_Norge.json";
    regionNumbersJson = File.ReadAllText(regionNumbersPath);
    var optionsRegion = new JsonSerializerOptions();
    List<RawRegion> rawRegions = JsonSerializer.Deserialize<RawRegion[]>(regionNumbersJson, optionsRegion).ToList();
    return rawRegions;
}
List<Workshop> ReadWorkshopsFromJson(out string workshopPath, out string workshopJson)
{
    //Serialize WorkshopsJSON into Workshop class
    workshopPath = @"C:\Users\simen\github\NORWorkshops\NORWorkshops\verkstedNEW.json";
    workshopJson = File.ReadAllText(workshopPath);
    var options = new JsonSerializerOptions();
    List<Workshop> list = JsonSerializer.Deserialize<Workshop[]>(workshopJson, options).ToList();
    return list;
}