using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Name Surname: ");
        string fullname = Console.ReadLine();
        Console.Write("Enter Mail: ");
        string email = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        User user = new User(fullname, email, password);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Create new group");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                user.ShowInfo();
            }
            else if (choice == 2)
            {
                Console.Write("Enter Group Number: ");
                string groupNo = Console.ReadLine();
                Console.Write("Enter Student Limit: ");
                int studentLimit = int.Parse(Console.ReadLine());

                Group group = new Group(groupNo, studentLimit);

                while (true)
                {
                    Console.WriteLine("Group Menu:");
                    Console.WriteLine("1. Show all students");
                    Console.WriteLine("2. Get student with id");
                    Console.WriteLine("3. Add student");
                    Console.WriteLine("0. Exit");
                    int groupChoice = int.Parse(Console.ReadLine());

                    if (groupChoice == 1)
                    {
                        foreach (var student in group.GetAllStudents())
                        {
                            if (student != null)
                                student.StudentInfo();
                        }
                    }
                    else if (groupChoice == 2)
                    {
                        Console.Write("Enter Student Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Student student = group.GetStudent(id);
                        if (student != null)
                            student.StudentInfo();
                        else
                            Console.WriteLine("Student not found.");
                    }
                    else if (groupChoice == 3)
                    {
                        Console.Write("Enter Fullname: ");
                        string studentFullname = Console.ReadLine();
                        Console.Write("Enter Grade: ");
                        double point = double.Parse(Console.ReadLine());
                        Student student = new Student(studentFullname, point);
                        group.AddStudent(student);
                    }
                    else if (groupChoice == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
