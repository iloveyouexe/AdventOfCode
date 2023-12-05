using AdventOfCode.Days;

namespace AdventOfCode.Tests.Year2023
{
    public class DayOneTests
    {
        [Fact]
        public void TestCalibrationSum()
        {
            // Arrange
            string[] testInput = { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            int expectedSum = 142;

            // Act
            int actualSum = DayOne.CalculateCalibrationSum(testInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}
