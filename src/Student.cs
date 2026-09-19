using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id;
    public string Name;
    public List<int> Grades = new List<int>();

    public double GetAverage()
    {
        if (Grades.Count == 0) return 0;
        int sum = 0;
        foreach (int grade in Grades) sum += grade;
        return (double)sum / Grades.Count;
    }

    public override string ToString() => $"[{Id}] {Name} - Average: {GetAverage():F1}";

}