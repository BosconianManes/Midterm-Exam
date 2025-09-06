namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int ID;
        public string Name = string.Empty;
        public string Course = string.Empty;
        public int Year;
        public double GPA;
        public Student? Prev = null;
        public Student? Next = null;
    }
}