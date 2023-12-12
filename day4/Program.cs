// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
int sum = 0;
List<int> cards = Enumerable.Repeat(1, 196).ToList();
int lineIterator = 0;
foreach (string line in File.ReadLines("input.txt")){
    int marker = line.IndexOf("|");
    int startMarker = line.IndexOf(":");
    string ownNumsLine = line.Substring(startMarker,marker - startMarker);
    string winningNumsLine = line.Substring(marker);
    string numberCap = @"\d+";
    MatchCollection matches = Regex.Matches(ownNumsLine, numberCap);
    List<int> ownNums = new List<int>();
    List<int> winningNums = new List<int>();
    foreach(Match match in matches){
        ownNums.Add(int.Parse(match.Value));
    }
    matches = Regex.Matches(winningNumsLine, numberCap);
    foreach(Match match in matches){
        winningNums.Add(int.Parse(match.Value));
    }
    //int numCount = ownNums.Except(winningNums).ToList().Count;
    //int numCount = ownNums.Where(i => winningNums.Contains(i)).ToList().Count;
    var list = winningNums.Where(i => ownNums.Contains(i)).ToList();
    int numCount = list.Count;
    int wins = numCount;//numCount == 0 ? 0 : (int)(Math.Pow(2,(numCount-1)));
    for (int i = lineIterator + 1; i < lineIterator + wins + 1; i++){
        cards[i] += cards[lineIterator];
        Console.WriteLine(cards[lineIterator]);
    }
    sum += cards[lineIterator];
    //cards[lineIterator]--;
    Console.WriteLine("line{0} : wins: {1}",lineIterator,cards[lineIterator]);
    lineIterator++;
}
Console.WriteLine(sum);