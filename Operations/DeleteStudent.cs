using StudentManagementSystem.DataStructures;
using System;

public class DeleteStudent
{
    private StudentList _list;

    public DeleteStudent(StudentList list)
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

        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        if (_list.DeleteById(id))
            Console.WriteLine("Student deleted.");
        else
            Console.WriteLine("Student not found.");
    }
}