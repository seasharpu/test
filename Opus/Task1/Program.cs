using System;
using Task1;

class Program
{
    static void Main()
    {
        string continueInput = "y";
        while (continueInput == "y")
        {
            Console.WriteLine("Enter no more than 2 numbers. no negative numbers.");
            string value = Console.ReadLine();
            Console.WriteLine(Calculator.Add(value));
            Console.WriteLine("continue y/n?");
            continueInput = Console.ReadLine();
        }
    }


    }
