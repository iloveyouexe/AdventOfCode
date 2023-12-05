using NUnit.Framework;
using AdventOfCode.Days; // Importing DayOne class namespace

namespace AdventOfCode.DaysTests
{
    public class DayOneTests
    {
        [Test]
        public void TestCalibrationSum()
        {
            // Arrange
            string[] testInput = { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            int expectedSum = 142;

            // Act
            int actualSum = DayOne.CalculateCalibrationSum(testInput);

            // Assert
            Assert.Equals(expectedSum, actualSum);
        }
    }
}
