#include 

int sum = 0;
foreach (string line in File.ReadLines("input.txt"))
{
    list<int> intArray = new intArray()[];
    foreach (char c in line){
        if (c.IsDigit()) {
            intArray.Add(c.ToInt());
        }
    }
    sum = sum + intArray[0]*10 + intArray[intArray.Length - 1];
    console.log(sum);
}
console.log(sum);