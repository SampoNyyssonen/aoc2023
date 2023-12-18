// See https://aka.ms/new-console-template for more information
List<Int64> seeds = new List<Int64>();
foreach (string line in File.ReadLines("input.txt")){
    seeds = line.Split(' ').Select(Int64.Parse).ToList();
}
Console.WriteLine(string.Join(", ", seeds));
Console.WriteLine("mapping s2s");
Dictionary<Int64,Int64> SeedSoilDict = new Dictionary<Int64,Int64>();
List<Int64> seedSoil = new List<Int64>();
foreach (string line in File.ReadLines("s2s.txt")){
    seedSoil = line.Split(' ').Select(Int64.Parse).ToList();
    foreach(Int64 seed in seeds){
        
        if (seed > seedSoil[1] && seed < seedSoil[2]){
            SeedSoilDict.Add(seed,seedSoil[2]+(seed-seedSoil[1]));
        }
    } 
}
SeedSoilDict.ToList().ForEach(kvp => Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}"));

Dictionary<Int64,Int64> SoilFertDict = new Dictionary<Int64,Int64>();
List<Int64> SoilFert = new List<Int64>();
foreach (string line in File.ReadLines("s2f.txt")){
    SoilFert = line.Split(' ').Select(Int64.Parse).ToList();
    foreach(KeyValuePair<Int64,Int64> soil in SeedSoilDict){
        if (soil.Key > SoilFert[1] && soil.Key < SoilFert[2]){
            SoilFertDict.Add(soil.Key,SoilFert[2]+(soil.Key-SoilFert[1]));
        }
    } 
}
SoilFertDict.ToList().ForEach(kvp => Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}"));
