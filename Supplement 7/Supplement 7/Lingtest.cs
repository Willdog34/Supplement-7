// See https://aka.ms/new-console-template for more information
using Xunit;

Console.WriteLine("Hello, World!");

public class LINQAssignment
{
    // Method to return all even numbers with an optional skip count
    public static IEnumerable<int> GetEvenNumbers(int[] array, int skipCount = 0)
    {
        return array.Where(x => x % 2 == 0).Skip(skipCount);
    }

    // Method to shuffle the array and return odd numbers with an optional skip count
    public static IEnumerable<int> GetShuffledOddNumbers(int[] array, int skipCount = 0)
    {
        Random rng = new Random();
        var shuffledArray = array.OrderBy(x => rng.Next()).ToArray();
        return shuffledArray.Where(x => x % 2 != 0).Skip(skipCount);
    }

    // Method to return the average, minimum, and maximum of the array
    public static (double Average, int Min, int Max) GetArrayStatistics(int[] array)
    {
        return (array.Average(), array.Min(), array.Max());
    }
}

// Unit Tests
public class LINQAssignmentTests
{
    private readonly int[] testArray;

    public LINQAssignmentTests()
    {
        testArray = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Fact]
    public void TestGetEvenNumbers()
    {
        var result = LINQAssignment.GetEvenNumbers(testArray, 5).ToList();
        Assert.NotEmpty(result);
        Assert.True(result.First() % 2 == 0);
    }

    [Fact]
    public void TestGetShuffledOddNumbers()
    {
        var result = LINQAssignment.GetShuffledOddNumbers(testArray, 10).ToList();
        Assert.NotEmpty(result);
        Assert.True(result.First() % 2 != 0);
    }

    [Fact]
    public void TestGetArrayStatistics()
    {
        var (avg, min, max) = LINQAssignment.GetArrayStatistics(testArray);
        Assert.Equal(499999.5, avg, precision: 1);
        Assert.Equal(0, min);
        Assert.Equal(999999, max);
    }
}

internal class FactAttribute : Attribute
{
}