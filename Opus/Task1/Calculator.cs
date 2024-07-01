using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Task1
{
    public class Calculator
    {
        static public string GetPosition(int index, int totalCount)
        {
            if (index == totalCount - 1)
            {
                return "last";
            }

            switch (index)
            {
                case 0:
                    return "first";
                case 1:
                    return "second";
                case 2:
                    return "third";
                default:
                    return (index + 1) + "th";
            }
        }

        static public string Add(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return "0";
            }

            double sum = 0;

            // Split the string by commas
            string[] numberStrings = number.Split(',');

        

            var negativeNumbers = new List<double>();

            for (int i = 0; i < numberStrings.Length; i++)
            {
                // Replace any spaces in the numberString before parsing
                string trimmedNumberString = numberStrings[i].Trim();

                // Check if the trimmedNumberString is empty after trimming
                if (trimmedNumberString.Length == 0)
                {
                    throw new InvalidOperationException($"Missing number in {GetPosition(i, numberStrings.Length)} position");
                }

                // Check for negative sign before parsing
                if (trimmedNumberString.StartsWith("-"))
                {
                    if (double.TryParse(trimmedNumberString, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out double negativeNumber))
                    {
                        negativeNumbers.Add(negativeNumber);
                    }
                    else
                    {
                        return $"Invalid number format: {trimmedNumberString}";
                    }
                }
                else
                {
                    // Attempt to parse the trimmed number string into a double
                    if (!double.TryParse(trimmedNumberString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double numbersToAdd))
                    {
                        return $"Invalid number format: {trimmedNumberString}";
                    }
                    sum += numbersToAdd;
                }
            }

            // If there are any negative numbers, throw an exception with the error message
            if (negativeNumbers.Any())
            {
                throw new InvalidOperationException($"Negative numbers not allowed: [{string.Join(", ", negativeNumbers)}]");
            }

            if (numberStrings.Length > 2)
            {
                return "Invalid amount of arguments";
            }


            string sumString = sum.ToString(CultureInfo.InvariantCulture);

            return sumString;
        }
    }
}
