using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class StudentSystem{
    private List<Student> students = new List<Student>();
    private int nextId = 1;
    
    public void AddStudent(Student s){
        s.Id = nextId++;
        students.Add(s);
    }

    public void createStudent(){

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        var student = new Student { Name = name };
        Console.Write("How many grades to enter? ");
        int count = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < count; i++){
            Console.Write($"Grade {i + 1}: ");
            int grade = Convert.ToInt32(Console.ReadLine());
            student.Grades.Add(grade);
        }
        AddStudent(student);
        Console.WriteLine($"{student.Name} has been added");
    }
    public void removeStudent(){
        Console.WriteLine("Enter id of Student to be Removed: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (students.Any(s => s.Id == id)){
            students.RemoveAll(i => i.Id == id);
            Console.WriteLine($"Student with Id {id} removed.");
        }
        else{
            Console.WriteLine("Student doesnt exist");
        }
    }
    public void listStudents(){
        if (students.Count == 0){
            Console.WriteLine("No students yet.");
        }
        foreach (var s in students){
            Console.WriteLine(s);
        }
    }
    public void SearchStudent(){
        Console.WriteLine("Enter id of student you want to find: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var found  = students.FirstOrDefault(s => s.Id == id);
        if (found != null){
            Console.WriteLine(found);
        }
        else{
            Console.WriteLine("Student does not exist");
        }
        

    }
    public void SaveToFile(string path)
    {
        var lines = new List<string>();
        foreach (var s in students)
        {
            string gradesJoined = string.Join(",", s.Grades);
            lines.Add($"{s.Id}|{s.Name}|{gradesJoined}");
        }
        File.WriteAllLines(path, lines);
        Console.WriteLine("Data saved.");
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            return; // nothing to load yet, first run
        }

        string[] lines = File.ReadAllLines(path);
        int highestId = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            int id = Convert.ToInt32(parts[0]);
            string name = parts[1];

            var grades = new List<int>();
            if (parts[2].Length > 0) // handles a student with zero grades
            {
                foreach (string g in parts[2].Split(','))
                {
                    grades.Add(Convert.ToInt32(g));
                }
            }

            var student = new Student { Id = id, Name = name, Grades = grades };
            students.Add(student);

            if (id > highestId) highestId = id;
        }

        nextId = highestId + 1;
    }


}