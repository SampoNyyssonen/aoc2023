// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
string previousLine = "............................................................................................................................................";
string middleLine = "............................................................................................................................................";;
int lineNo = 0;
int sum = 0;
string starCapture = @"\*";

int multRes(List<int> l1, List<int> l2, List<int> l3){
    if (l1.Count == 1 && l2.Count == 1){
        return l1[0]*l2[0];
    }else if (l1.Count == 1 && l3.Count == 1){
        return l1[0]*l3[0];
    }else if (l2.Count == 1 && l3.Count == 1){
        return l2[0]*l3[0];
    }else if (l1.Count == 2){
        return l1[0]*l1[1];
    }else if (l2.Count == 2){
        return l2[0]*l2[1];
    }else if (l3.Count == 2){
        return l3[0]*l3[1];
    }
    return 0;
}

List<int> findNum(int matchIndex, string matchValue, string line){
    int len = matchValue.Length;
    string numberCap = @"\d+";
    MatchCollection matches = Regex.Matches(line, numberCap);
    int foundcount = 0;
    List<int> foundList = new List<int>();
    foreach (Match number in matches){
        int numberLen = number.Length; 
        if ((number.Index + numberLen >= matchIndex && number.Index <= matchIndex + len)){
            Console.WriteLine("found number char {0} in pos {1} for int {2} on line {3}", number.Value, number.Index, matchValue, lineNo);
            foundList.Add(int.Parse(number.Value.ToString()));
        }
    }
    return foundList;
}
foreach (string line in File.ReadLines("input.txt"))
{   

    if (lineNo >= 1){
        MatchCollection matches = Regex.Matches(middleLine, starCapture);
        //Console.WriteLine(previousLine);
        //Console.WriteLine(middleLine);
        //Console.WriteLine(line);
        foreach (Match match in matches){
            //Console.WriteLine("checking {0}", match);
            List<int> prevResult = findNum(match.Index, match.Value, previousLine);
            int prevLen = prevResult.Count;
            if (prevLen <= 2){
                List<int> middleResult = findNum(match.Index, match.Value, middleLine);
                int middleLen = middleResult.Count;
                if (middleLen + prevLen <= 2){
                    List<int> nextResult = findNum(match.Index, match.Value, line);
                    int nextLen = nextResult.Count;
                    if (middleLen + prevLen + nextLen == 2){
                        sum += multRes(prevResult,middleResult,nextResult);
                        Console.WriteLine(sum);

                    }
                }
            
            }

        }
    }
    previousLine = middleLine;    
    middleLine = line;
    lineNo++;
}

MatchCollection LastMatches = Regex.Matches(middleLine, starCapture);
//Console.WriteLine(previousLine);
//Console.WriteLine(middleLine);
//Console.WriteLine(line);
foreach (Match match in LastMatches){
    Console.WriteLine("checking {0}", match);
    List<int> prevResult = findNum(match.Index, match.Value, previousLine);
    int prevLen = prevResult.Count;
    if (prevLen <= 2){
        List<int> middleResult = findNum(match.Index, match.Value, middleLine);
        int middleLen = middleResult.Count;
        if (middleLen + prevLen == 2){
            List<int> nextResult = new List<int>();
            int nextLen = nextResult.Count;
            if (middleLen + prevLen + nextLen == 2){
                sum += multRes(prevResult,middleResult,nextResult);
            }
        }
    
    }

}
Console.WriteLine(sum);
