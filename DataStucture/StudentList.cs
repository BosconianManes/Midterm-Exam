using StudentManagementSystem.Models;

namespace StudentManagementSystem.DataStructures
{
    public class StudentList
    {
        public Student? Head { get; private set; } = null;

        public bool Exists(int id)
        {
            Student? current = Head;
            while (current != null)
            {
                if (current.ID == id) return true;
                current = current.Next;
            }
            return false;
        }

        public void AddAtBeginning(Student newNode)
        {
            newNode.Next = Head;
            if (Head != null) Head.Prev = newNode;
            newNode.Prev = null;
            Head = newNode;
        }

        public void AddAtEnd(Student newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                newNode.Prev = null;
                newNode.Next = null;
                return;
            }

            Student current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Prev = current;
            newNode.Next = null;
        }

        public bool AddAtPosition(Student newNode, int pos)
        {
            if (pos < 1) return false;

            if (pos == 1)
            {
                AddAtBeginning(newNode);
                return true;
            }

            Student? current = Head;
            int count = 1;
            while (current != null && count < pos)
            {
                current = current.Next;
                count++;
            }

            if (current == null && count == pos)
            {
                AddAtEnd(newNode);
                return true;
            }

            if (current == null) return false;

            newNode.Prev = current.Prev;
            newNode.Next = current;
            if (current.Prev != null)
                current.Prev.Next = newNode;
            current.Prev = newNode;
            return true;
        }

        public bool DeleteById(int id)
        {
            Student? current = Head;
            while (current != null && current.ID != id) current = current.Next;

            if (current == null) return false;

            if (current == Head) Head = Head.Next;
            if (current.Prev != null) current.Prev.Next = current.Next;
            if (current.Next != null) current.Next.Prev = current.Prev;

            return true;
        }

        public Student? SearchById(int id)
        {
            Student? current = Head;
            while (current != null)
            {
                if (current.ID == id) return current;
                current = current.Next;
            }
            return null;
        }

        public void DisplayAll()
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            Student? current = Head;
            while (current != null)
            {
                Console.WriteLine($"ID: {current.ID}, Name: {current.Name}, Course: {current.Course}, Year: {current.Year}, GPA: {current.GPA}");
                current = current.Next;
            }
        }
    }
}