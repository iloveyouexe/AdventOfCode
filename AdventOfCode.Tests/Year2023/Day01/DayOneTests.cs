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
        var actualSum = Day1A.Solve(testInput);

        // Assert
        Assert.Equal(expectedSum, actualSum);
    }
    
    [Fact]
    public void Test2Solve()
    {
        // Arrange
        string[] testInput = { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };
        var expectedSum = "281";

        // Act
        var actualSum = Day1B.Solve(testInput);

        // Assert
        Assert.Equal(expectedSum, actualSum);
    }
}