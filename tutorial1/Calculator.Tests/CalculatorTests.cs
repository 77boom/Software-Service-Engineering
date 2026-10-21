using System.Reflection;

namespace Calculator.Tests
{
    public class CalculatorTests
    {

        [Fact] //  mark the below method is a test
        public void Multiply_TwoNumbers_ReturnsCorrectResult() //the name of test， void is mean this dont return a result
        {
            // Given
            var calculator = new Calculator();

            // When
            double result = calculator.Multiply(2.0, 3.0);

            // Then
            Assert.Equal(6.0, result);

        }

        [Fact]
        public void Divide_TwoNumbers_ReturnsCorrectResult()
        {
            // Given
            var calculator =  new Calculator();

            // When
            double result = calculator.Divide(6.0, 3.0);

            // Then
            Assert.Equal(2.0, result);
        }

        [Fact]
        public void Divide_ByZero_ReturnsNaN()
        {
            // Given
            var calculator = new Calculator();
        
            // When
            double result = calculator.Divide(6.0, 0.0);
        
            // Then
            Assert.True(double.IsNaN(result));  //check if the result is NaN， if it is, return true
            
        }
    }
}