using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using Task2API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Task2API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
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


        [HttpPost("sum")]
        public async Task<ActionResult<NumbersDto>> Sum(NumbersDto dto)
        {
            if (string.IsNullOrEmpty(dto.Numbers))
            {
                // Return 0 if input is empty
                return Ok(new NumbersDto { Numbers = "0" }); // Returning "0" as a string in dto
            }

            double sum = 0;

            // Split the string by commas
            string[] numberStrings = dto.Numbers.Split(',');



            var negativeNumbers = new List<double>();

            for (int i = 0; i < numberStrings.Length; i++)
            {
                // Replace any spaces in the numberString before parsing
                string trimmedNumberString = numberStrings[i].Trim();

                // Check if the trimmedNumberString is empty after trimming
                if (trimmedNumberString.Length == 0)
                {
                    return BadRequest($"Missing number in {GetPosition(i, numberStrings.Length)} position");
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
                        return BadRequest($"Invalid number format: {trimmedNumberString}");
                    }
                }
                else
                {
                    // Attempt to parse the trimmed number string into a double
                    if (!double.TryParse(trimmedNumberString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double numbersToAdd))
                    {
                        return BadRequest($"Invalid number format: {trimmedNumberString}");
                    }
                    sum += numbersToAdd;
                }
            }

            // If there are any negative numbers, return bad request with error message
            if (negativeNumbers.Any())
            {
                return BadRequest($"Negative numbers not allowed: [{string.Join(", ", negativeNumbers)}]");
            }

            if (numberStrings.Length > 2)
            {
                return BadRequest("Invalid amount of arguments");
            }


            string sumString = sum.ToString(CultureInfo.InvariantCulture);

            var dtoReturn = new NumbersDto()
            {
                Numbers = sumString
            };


            return Ok(dtoReturn);
        }
    }
}


