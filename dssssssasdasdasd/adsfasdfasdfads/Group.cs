using System.Text.RegularExpressions;

class Group
{
    public string GroupNo { get; }
    public int StudentLimit { get; }
    private Student[] Students { get; set; }
    private int _studentCount = 0;

    public Group(string groupNo, int studentLimit)
    {
        if (studentLimit < 5 || studentLimit > 18)
            throw new ArgumentException("Student limit must be 5 and 18");
        if (!CheckGroupNo(groupNo))
            throw new ArgumentException("Group number is not valid.");
        GroupNo = groupNo;
        StudentLimit = studentLimit;
        Students = new Student[studentLimit];
    }

    public bool CheckGroupNo(string groupNo)
    {
        if (groupNo.Length != 5)
            return false;

        for (int i = 0; i < 2; i++)
        {
            if (!char.IsUpper(groupNo[i]))
                return false;
        }

        for (int i = 2; i < 5; i++)
        {
            if (!char.IsDigit(groupNo[i]))
                return false;
        }

        return true;
    }

    public void AddStudent(Student student)
    {
        if (_studentCount >= StudentLimit)
        {
            Console.WriteLine("Cannot add more students, limit reached.");
            return;
        }
        Students[_studentCount++] = student;
    }

    public Student GetStudent(int? id)
    {
        if (id == null) return null;
        foreach (var student in Students)
        {
            if (student != null && student.Id == id)
                return student;
        }
        return null;
    }

    public Student[] GetAllStudents()
    {
        Student[] result = new Student[_studentCount];
        Array.Copy(Students, result, _studentCount);
        return result;
    }
}
