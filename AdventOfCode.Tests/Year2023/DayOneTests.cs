using AdventOfCode.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class DayOneTests
{
    [Fact]
    public void TestSolve()
    {
        // Arrange
        string[] testInput = { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
        var expectedSum = "142";

        // Act
        var actualSum = Day1.Solve(testInput);

        // Assert
        Assert.Equal(expectedSum, actualSum);
    }
}