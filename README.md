# Student Record Manager

A console-based student record management system built in C#, written as a project to learn core C# and OOP concepts.

## Features

- Add a student with a name and a set of grades
- Remove a student by ID
- List all students along with their calculated average grade
- Search for a student by ID
- Saves all students to a file on exit and loads them back in on startup, so data persists between runs

## Concepts Demonstrated

- Object-oriented programming (encapsulation, separation of concerns across classes)
- Method overloading
- Collections (`List<T>`)
- LINQ (`FirstOrDefault`, filtering/searching)
- File I/O (reading/writing plain text with a custom delimited format)
- Console-based menu-driven program flow
- Unit testing with xUnit (`[Fact]` tests, assertions, redirecting `Console` input/output, temp files for I/O tests)

## Project Structure

```
src/
├── Student.cs        # Represents a single student (Id, Name, Grades, GetAverage())
├── StudentSystem.cs  # Manages the collection of students (add, remove, search, list, save/load)
├── Program.cs        # Entry point and menu loop
└── C#.csproj         # Project file
tests/
├── StudentTests.cs        # Unit tests for Student (averages, ToString)
├── StudentSystemTests.cs  # Unit tests for StudentSystem (add, list, remove, search, save/load)
└── Tests.csproj           # xUnit test project
```

## How to Run

```bash
git clone https://github.com/ishaq231/StudentRecordManager.git
cd StudentRecordManager/src
dotnet run
```

Student data is stored in `students.txt` (created automatically in the working directory the first time you exit).

## Running the Tests

The project has 12 xUnit unit tests. From the repository root:

```bash
dotnet test tests
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

Complete — core CRUD operations and file persistence are in place. Built while learning C#.

## Author

Ishaq Modassir Mushtaq