using StudentManagementSystem.DataStructures;
using StudentManagementSystem.Models;
using System;

public class SearchStudent
{
    private StudentList _list;

    public SearchStudent(StudentList list)
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

        Console.Write("Enter ID to search: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Student? student = _list.SearchById(id);
        if (student != null)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Course: {student.Course}, Year: {student.Year}, GPA: {student.GPA}");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Student not found.");
        }
    }
}