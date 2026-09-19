using System.Collections.Generic;

static class Seed
{
    public static List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student { Name = "Alice Johnson", Grades = new List<int> { 90, 85, 92 } },
            new Student { Name = "Bob Smith",     Grades = new List<int> { 60, 65, 58 } },
            new Student { Name = "Charlie Brown",  Grades = new List<int> { 78, 82, 74 } },
            new Student { Name = "Diana Prince",   Grades = new List<int> { 95, 98, 93 } },
            new Student { Name = "Ethan Hunt",     Grades = new List<int> { 55, 60, 62 } },
            new Student { Name = "Fiona Gallagher",Grades = new List<int> { 71, 68, 75 } }
        };
    }
}