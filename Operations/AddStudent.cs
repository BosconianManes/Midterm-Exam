using System;
using StudentManagementSystem.DataStructures;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Operations
{
    public class AddStudent
    {
        private StudentList _list;

        public AddStudent(StudentList list)
        {
            _list = list;
        }

        public void Execute()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Where to add?");
                Console.WriteLine("1. At Beginning");
                Console.WriteLine("2. At End");
                Console.WriteLine("3. At Specific Position");
                Console.Write("Enter choice (1-3): ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
                    break;
                Console.Clear();
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
            }

            int id;
            do
            {
                Console.Write("Enter ID: ");
                string? idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out id) || id <= 0)
                {
                    Console.WriteLine("Invalid ID. Please enter a positive integer.");
                    continue;
                }
                if (_list.Exists(id))
                {
                    Console.Clear();
                    Console.WriteLine("ID already exists, try again.");
                    continue;
                }
                break;
            } while (true);

            string name;
            do
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(name));

            string course;
            do
            {
                Console.Write("Enter Course: ");
                course = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(course))
                    Console.WriteLine("Course cannot be empty.");
            } while (string.IsNullOrWhiteSpace(course));

            int year;
            while (true)
            {
                Console.Write("Enter Year : ");
                string? yearInput = Console.ReadLine();
                if (int.TryParse(yearInput, out year) && year >= 1 && year <= 6)
                    break;
                Console.WriteLine("Invalid Year.");
            }

            double gpa;
            while (true)
            {
                Console.Write("Enter GPA ");
                string? gpaInput = Console.ReadLine();
                if (double.TryParse(gpaInput, out gpa) && gpa >= 0.0 && gpa <= 4.0)
                    break;
                Console.WriteLine("Invalid GPA.");
            }

            Student newNode = new Student { ID = id, Name = name, Course = course, Year = year, GPA = gpa };

            if (choice == 1)
            {
                _list.AddAtBeginning(newNode);
                Console.WriteLine("Added at beginning.");
            }
            else if (choice == 2)
            {
                _list.AddAtEnd(newNode);
                Console.WriteLine("Added at end.");
            }
            else if (choice == 3)
            {
                int pos;
                while (true)
                {
                    Console.Write("Enter position: ");
                    string? posInput = Console.ReadLine();
                    if (int.TryParse(posInput, out pos) && pos > 0)
                        break;
                    Console.WriteLine("Invalid position. Please enter a positive integer.");
                }

                if (_list.AddAtPosition(newNode, pos))
                    Console.WriteLine($"Added at position {pos}.");
                else
                    Console.WriteLine("Invalid position.");
            }
        }
    }
}