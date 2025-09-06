using StudentManagementSystem.DataStructures;
using System;

public class DisplayAllStudents
{
    private StudentList _list;

    public DisplayAllStudents(StudentList list)
    {
        _list = list;
    }

    public void Execute()
    {
        _list.DisplayAll();
    }
}