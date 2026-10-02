using Xunit;

public class StudentSystemTests : IDisposable
{
    private readonly string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
    private readonly TextWriter originalOut = Console.Out;
    private readonly StringWriter output = new StringWriter();

    public StudentSystemTests() => Console.SetOut(output);

    public void Dispose()
    {
        Console.SetOut(originalOut);
        if (File.Exists(path)) File.Delete(path);
    }

    [Fact]
    public void AddStudent_AssignsSequentialIds()
    {
        var system = new StudentSystem();
        var a = new Student { Name = "A" };
        var b = new Student { Name = "B" };
        system.AddStudent(a);
        system.AddStudent(b);
        Assert.Equal(1, a.Id);
        Assert.Equal(2, b.Id);
    }

    [Fact]
    public void ListStudents_Empty_PrintsNoStudentsMessage()
    {
        new StudentSystem().listStudents();
        Assert.Contains("No students yet.", output.ToString());
    }

    [Fact]
    public void ListStudents_PrintsEachStudent()
    {
        var system = new StudentSystem();
        system.AddStudent(new Student { Name = "Alice" });
        system.AddStudent(new Student { Name = "Bob" });
        system.listStudents();
        var text = output.ToString();
        Assert.Contains("Alice", text);
        Assert.Contains("Bob", text);
    }

    [Fact]
    public void RemoveStudent_ExistingId_RemovesIt()
    {
        var system = new StudentSystem();
        system.AddStudent(new Student { Name = "Alice" });
        Console.SetIn(new StringReader("1\n"));
        system.removeStudent();
        Assert.Contains("Student with Id 1 removed.", output.ToString());
        output.GetStringBuilder().Clear();
        system.listStudents();
        Assert.Contains("No students yet.", output.ToString());
    }

    [Fact]
    public void RemoveStudent_UnknownId_PrintsNotFound()
    {
        var system = new StudentSystem();
        Console.SetIn(new StringReader("99\n"));
        system.removeStudent();
        Assert.Contains("Student doesnt exist", output.ToString());
    }

    [Fact]
    public void SearchStudent_ExistingId_PrintsStudent()
    {
        var system = new StudentSystem();
        system.AddStudent(new Student { Name = "Alice", Grades = new List<int> { 100 } });
        Console.SetIn(new StringReader("1\n"));
        system.SearchStudent();
        Assert.Contains("[1] Alice - Average: 100.0", output.ToString());
    }

    [Fact]
    public void SaveThenLoad_RoundTripsStudentsAndContinuesIds()
    {
        var system = new StudentSystem();
        system.AddStudent(new Student { Name = "Alice", Grades = new List<int> { 90, 80 } });
        system.AddStudent(new Student { Name = "Bob" }); // no grades
        system.SaveToFile(path);

        Assert.Equal(new[] { "1|Alice|90,80", "2|Bob|" }, File.ReadAllLines(path));

        var loaded = new StudentSystem();
        loaded.LoadFromFile(path);
        var next = new Student { Name = "Carol" };
        loaded.AddStudent(next);
        Assert.Equal(3, next.Id);

        output.GetStringBuilder().Clear();
        loaded.listStudents();
        var text = output.ToString();
        Assert.Contains("[1] Alice - Average: 85.0", text);
        Assert.Contains("[2] Bob - Average: 0.0", text);
    }
}
