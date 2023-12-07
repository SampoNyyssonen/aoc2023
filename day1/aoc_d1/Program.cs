// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
//Console.WriteLine("Hello, World!");


string parseNumbers(string s){
    string retString = s.ToLower(); 
    bool found = true;
    int[] foundNum = new int[100];
    string foundStr = "";
    List<string> num = ["1","2","3","4","5","6","7","8","9"];
    List<string> numbers = ["one","two","three","four","five","six","seven","eight","nine"];
    int numIx = 0;
    for (int i = numbers.Count -1; i >=0; i--){
        int foundPos = retString.IndexOf(numbers[i]);
        
        if (foundPos >= 0){
            foundNum[foundPos] = i+1;
            //foundStr.Insert(foundPos,(i+1).ToString());
        }
        int lastFoundPos = retString.LastIndexOf(numbers[i]);
        if (lastFoundPos >= 0){
            foundNum[lastFoundPos] = i+1;
            //foundStr.Insert(foundPos,(i+1).ToString());
        }
    }
    for (int i = 0; i < num.Count; i++){
        //foundNum[i] = i+1;
        int foundPos = retString.IndexOf(num[i]);
        if (foundPos >= 0){
            foundNum[foundPos] = i+1;
        }
        int lastFoundPos = retString.LastIndexOf(num[i]);
        if (lastFoundPos >= 0){
            foundNum[lastFoundPos] = i+1;
        }
    }
    for (int i = 0; i < 100; i++){
        if (foundNum[i] >= 1 && foundNum[i] <=9 ){
            foundStr += foundNum[i].ToString();
        }
        
    }
    return foundStr;
}
int sum = 0;
foreach (string line in File.ReadLines("input.txt"))
{   
    string newLine = parseNumbers(line);
    List<int> intArray = new List<int>();
    Console.WriteLine(line);
    Console.WriteLine(newLine);
    foreach (char c in newLine){

        if (char.IsDigit(c)) {
            intArray.Add(int.Parse(c.ToString()));
        }
    }
    sum = sum + (intArray[0]*10 + intArray[intArray.Count - 1]);
    Console.WriteLine(sum);
}
Console.WriteLine(sum);
