using System;
using System.Collections.Generic;
using System.Linq;

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
        AddStudent(student)
        Console.WriteLine($"{student.name} has been added");
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
    public var SearchStudent(){
        console.WriteLine("Enter id of student you want to find: ");
        int id = Convert.ToInt32(console.ReadLine());
        var found  = students.FirstOrDefault(s => s.id = id);
        if (found == null){
            Console.WriteLine("Student does not exist");
        }
        return found;
        

    }


}