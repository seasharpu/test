using System;
using Task1;

class Program
{
    static void Main()
    {
        Console.WriteLine(Calculator.Add(""));
        Console.WriteLine(Calculator.Add("1"));
        Console.WriteLine(Calculator.Add("5,7"));
        Console.WriteLine(Calculator.Add("1.1,3.4"));
     //  Console.WriteLine(Calculator.Add("1,5,"));
        // Console.WriteLine(Calculator.Add("1,3,"));
       Console.WriteLine(Calculator.Add("7, -4, 1, -5"));
    }

    
}
