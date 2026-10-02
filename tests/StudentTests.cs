using Xunit;

public class StudentTests
{
    [Fact]
    public void GetAverage_NoGrades_ReturnsZero()
    {
        var s = new Student { Name = "A" };
        Assert.Equal(0, s.GetAverage());
    }

    [Fact]
    public void GetAverage_SingleGrade_ReturnsThatGrade()
    {
        var s = new Student { Name = "A", Grades = new List<int> { 80 } };
        Assert.Equal(80, s.GetAverage());
    }

    [Fact]
    public void GetAverage_MultipleGrades_ReturnsMean()
    {
        var s = new Student { Name = "A", Grades = new List<int> { 70, 80, 90 } };
        Assert.Equal(80, s.GetAverage());
    }

    [Fact]
    public void GetAverage_NonIntegerMean_UsesFloatingPointDivision()
    {
        var s = new Student { Name = "A", Grades = new List<int> { 1, 2 } };
        Assert.Equal(1.5, s.GetAverage());
    }

    [Fact]
    public void ToString_FormatsIdNameAndAverage()
    {
        var s = new Student { Id = 3, Name = "Bob", Grades = new List<int> { 90, 85 } };
        Assert.Equal($"[3] Bob - Average: {87.5:F1}", s.ToString());
    }
}
