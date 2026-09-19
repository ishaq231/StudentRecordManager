    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program{
        public void initiateSystem(var system){
            foreach (var s in Seed.GetStudents()){
                system.AddStudent(s);
            }
        }
        static void Main(){
            StudentSystem system = new StudentSystem();
            initiateSystem(system);
            Console.WriteLine("Welcome to the Student Managment System ");
            while(true){
                Console.WriteLine("Select from the following options: \n1. Add student \n2. Remove student\n3. List students \n4. Search Student \n5. Exit\n");
                string choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice)){
                    Console.WriteLine("You didn't enter anything.");
                    continue;
                }
                switch (choice){
                    case "1":
                        system.createStudent();
                        break;
                    case "2": 
                        system.removeStudent();
                        break;
                    case "3":
                        system.listStudents();
                        break;
                    case "4":
                        system.SearchStudent();
                        break;
                    case "5":
                        break;
                    default:
                    Console.WriteLine("Invalid Input");
                    break;
                } 
            }
        }
    }