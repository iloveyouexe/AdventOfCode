using AdventOfCode.Days;

namespace AdventOfCode.Tests.Year2023
{
    public class DayOneTests
    {
        [Fact]
        public void TestSolve()
        {
            // Arrange
            string[] testInput = { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
            string expectedSum = "142";

            // Act
            string actualSum = DayOne.Solve(testInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}
