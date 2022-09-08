using Soltys.JsonFishOil;

var query = File.ReadAllText("make_obj.txt");
var jsonData = File.ReadAllText("data.json");


Console.WriteLine(Engine.RunFishOil(query, jsonData));
