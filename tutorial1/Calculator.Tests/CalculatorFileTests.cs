using Moq;

namespace Calculator.Tests
{
    public class CalculatorFileTests
    {
        [Fact]
        public void Multiply_WriteResult()
        {
            // Given
            var writerMock = new Mock<IResultWriter>();
            var calculator = new Calculator(writerMock.Object);

            // When
            double result = calculator.Multiply(2.0, 3.0);

            // Then
            Assert.Equal(6.0, result);

            writerMock.Verify(
                writer => writer.WriteResult(6.0),
                Times .Once); // 检查 Calculator 有没有调用 Writer 的 WriteResult(6.0)，并且只调用了一次
        }


        [Fact]
        public void Divide_WritesResult()
        {
            var writerMock = new Mock<IResultWriter>();
            var calculator = new Calculator(writerMock.Object);

            //when
            double result = calculator.Divide(6.0, 3.0);

            //Then
            Assert.Equal(2.0, result);
            writerMock.Verify(
                writer => writer.WriteResult(2.0),
                Times.Once);
        }

        [Fact]
        public void Divide_ByZero_WritesNaN()
        {   
            // Given
            var writerMock = new Mock<IResultWriter>();
            var calculator = new Calculator(writerMock.Object);

            // When
            double result = calculator.Divide(6.0, 0.0);

            // Then
            Assert.True(double.IsNaN(result));

            writerMock.Verify(
                writer => writer.WriteResult(
                    It.Is<double>(value => double.IsNaN(value))),
            Times.Once);
        }

        [Fact]
        public void Multiply_WhenWritingFails_ThrowsIOException()
        {
            // Given
            var writerMock = new Mock<IResultWriter>();

            writerMock
                .Setup(writer => writer.WriteResult(It.IsAny<double>()))
                .Throws(new IOException()); //  在设置只要有 人叫writeresult，， 就故意报一个ioexception

            var calculator = new Calculator(writerMock.Object);


            // When + Then
            Assert.Throws<IOException>(
                () => calculator.Multiply(2.0, 3.0));
        }  

        [Fact]
        public void Divide_WhenWritingFails_ThrowsIOException()
        {
            // Given
            var writerMock = new Mock<IResultWriter>();

            writerMock
                .Setup(writer => writer.WriteResult(It.IsAny<double>()))
                .Throws(new IOException());

            var calculator = new Calculator(writerMock.Object);

            // When + Then
            Assert.Throws<IOException>(
                () => calculator.Divide(6.0, 3.0));
        }
    }
}