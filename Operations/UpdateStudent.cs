using StudentManagementSystem.DataStructures;
using StudentManagementSystem.Models;
using System;

public class UpdateStudent
{
    private StudentList _list;

    public UpdateStudent(StudentList list)
    {
        _list = list;
    }

    public void Execute()
    {
        if (_list.Head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        int id;
        while (true)
        {
            Console.Write("Enter ID to update: ");
            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                break;
            Console.WriteLine("Invalid ID. Please enter a positive integer.");
        }

        Student? student = _list.SearchById(id);
        if (student != null)
        {
            string name;
            do
            {
                Console.Write("Enter new Name: ");
                name = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.Clear();
                    Console.WriteLine("Name cannot be empty.");
                }
            } while (string.IsNullOrWhiteSpace(name));
            student.Name = name;

            string course;
            do
            {
                Console.Write("Enter new Course: ");
                course = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(course))
                {
                    Console.Clear();
                    Console.WriteLine("Course cannot be empty.");
                }
            } while (string.IsNullOrWhiteSpace(course));
            student.Course = course;

            int year;
            while (true)
            {
                Console.Write("Enter new Year : ");
                if (int.TryParse(Console.ReadLine(), out year) && year >= 1 && year <= 4)
                    break;
                Console.WriteLine("Invalid Year.");
            }
            student.Year = year;

            double gpa;
            while (true)
            {
                Console.Write("Enter new GPA : ");
                if (double.TryParse(Console.ReadLine(), out gpa) && gpa >= 0.0 && gpa <= 4.0)
                    break;
                Console.WriteLine("Invalid GPA.");
            }
            student.GPA = gpa;

            Console.WriteLine("Student updated.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}