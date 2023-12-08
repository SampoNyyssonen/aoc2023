using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

List<int> MaxColor = new List<int>();
int sum = 0;
int gameNum = 1;
foreach (string line in File.ReadLines("input.txt"))
{   
    string redCapture = @"(\d+) red";
    string greenCapture = @"(\d+) green";
    string blueCapture = @"(\d+) blue";
    
    List<int> MaxCheck = [12,13,14]; //12 Red, 13 Green, 14 Blue 
    bool fail = false;
    MatchCollection matches = Regex.Matches(line, blueCapture);
    int maxBlue = 0;
    int maxRed = 0;
    int maxGreen = 0;
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;
        Console.WriteLine(match.Value);
        int capVal = int.Parse(groups[1].ToString());
        if (capVal > maxBlue) {
            maxBlue = capVal;
        }
    }
    matches = Regex.Matches(line, greenCapture);
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;
        int capVal = int.Parse(groups[1].ToString());

        if (capVal > maxGreen) {
            maxGreen = capVal;
        }
    }
    matches = Regex.Matches(line, redCapture);
    foreach (Match match in matches)
    {
        GroupCollection groups = match.Groups;
        int capVal = int.Parse(groups[1].ToString());
        if (capVal > maxRed) {
            maxRed = capVal;
        }
    }
    sum += maxBlue*maxRed*maxGreen;
    Console.WriteLine(sum);
}
Console.WriteLine(sum);