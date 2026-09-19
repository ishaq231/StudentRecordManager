# Student Record Manager

A console-based student record management system built in C#, written as a project to learn core C# and OOP concepts.

## Features

- Add a student with a name and a set of grades
- Remove a student by ID
- List all students along with their calculated average grade
- Search for a student by ID
- Loads a set of seed students automatically on startup

## Concepts Demonstrated

- Object-oriented programming (encapsulation, separation of concerns across classes)
- Method overloading
- Collections (`List<T>`)
- LINQ (`FirstOrDefault`, filtering/searching)
- Console-based menu-driven program flow

## Project Structure

```
src/
├── Student.cs        # Represents a single student (Id, Name, Grades, GetAverage())
├── StudentSystem.cs  # Manages the collection of students (add, remove, search, list)
├── Seed.cs           # Provides sample student data on startup
├── Program.cs        # Entry point and menu loop
└── C#.csproj         # Project file
```

## How to Run

```bash
git clone https://github.com/ishaq231/StudentRecordManager.git
cd StudentRecordManager/src
dotnet run
```

## Menu Options

```
1. Add student
2. Remove student
3. List students
4. Search Student
5. Exit
```

## Status

Work in progress, built while learning C#. Planned next step: saving and loading student records to a file so data persists between runs.

## Author

Ishaq Modassir Mushtaq
