using StudentManagementSystem.DataStructures;
using StudentManagementSystem.Operations;
using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════");
            Console.WriteLine("╟───────────STUDENT MANAGEMENT SYSTEM──────╢");
            Console.WriteLine("════════════════════════════════════════════");
            Console.WriteLine("  [1] Add Student                          ║");
            Console.WriteLine("  [2] Delete Student                       ║");
            Console.WriteLine("  [3] Search Student                       ║");
            Console.WriteLine("  [4] Update Student                       ║");
            Console.WriteLine("  [5] Display All Students                 ║");
            Console.WriteLine("  [6] Exit                                 ║");
            Console.WriteLine("════════════════════════════════════════════");
            Console.Write("Enter your choice: ");
        }

        static void Main()
        {
            StudentList list = new StudentList();

            AddStudent add = new AddStudent(list);
            DeleteStudent delete = new DeleteStudent(list);
            SearchStudent search = new SearchStudent(list);
            UpdateStudent update = new UpdateStudent(list);
            DisplayAllStudents display = new DisplayAllStudents(list);

            int choice;
            do
            {
                ShowMenu();

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1: add.Execute(); break;
                    case 2: delete.Execute(); break;
                    case 3: search.Execute(); break;
                    case 4: update.Execute(); break;
                    case 5: display.Execute(); break;
                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (choice != 6)
                {
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }

            } while (choice != 6);
        }
    }
}
