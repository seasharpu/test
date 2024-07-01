namespace Task1Tester
{
    using System;
    using Xunit;
    using Task1; // Replace with your actual namespace if different

    public class CalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsEmpty()
        {
            // Arrange
            string number = "";

            // Act
            string result = Calculator.Add(number);

            // Assert
            Assert.Equal("0", result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            string number = "1";

            // Act
            string result = Calculator.Add(number);

            // Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void Add_TwoNumbersWithComma_ReturnsSum()
        {
            // Arrange
            string number = "5,7";

            // Act
            string result = Calculator.Add(number);

            // Assert
            Assert.Equal("12", result);
        }

        [Fact]
        public void Add_TwoNumbersWithPeriodAndComma_ReturnsSum()
        {
            // Arrange
            string number = "1.1 , 3.4";

            // Act
            string result = Calculator.Add(number);

            // Assert
            Assert.Equal("4.5", result);
        }

        [Fact]
        public void Add_NegativeNumber_ThrowsInvalidOperationException()
        {
            // Arrange
            string number = "-1,1,-5";

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => Calculator.Add(number));

            // Assert
            Assert.Equal("Negative numbers not allowed: [-1, -5]", exception.Message);
        }

        [Fact]
        public void Add_EmptyNumberAfterComma_ThrowsInvalidOperationException()
        {
            // Arrange
            string number = "1.3, ";

            // Act and Assert
            var exception = Assert.Throws<InvalidOperationException>(() => Calculator.Add(number));

            // Assert
            Assert.Contains("Missing number", exception.Message);
        }

        [Fact]
        public void Add_TooManyArguments_ReturnsErrorMessage()
        {
            // Arrange
            string number = "1,2,3";

            // Act
            string result = Calculator.Add(number);

            // Assert
            Assert.Equal("Invalid amount of arguments", result);
        }
    }

}