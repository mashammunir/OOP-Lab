using System;
using System.Collections.Generic;

class Subject
{
    public int code;
    public string type;
    public int creditHours;
    public float fees;

    public Subject(int c, string t, int ch, float f)
    {
        code = c; type = t; creditHours = ch; fees = f;
    }

    public void Display()
    {
        Console.WriteLine("  Code: " + code + " | Type: " + type +
            " | Credit Hours: " + creditHours + " | Fees: " + fees);
    }
}

class DegreeProgram
{
    public string name;
    public int duration;
    public int seats;
    public int seatsLeft;
    public List<Subject> subjects = new List<Subject>();

    public DegreeProgram(string n, int d, int s)
    {
        name = n; duration = d; seats = s; seatsLeft = s;
    }

    public void AddSubject(Subject s) { subjects.Add(s); }

    public float GetTotalFees()
    {
        float total = 0;
        foreach (Subject s in subjects) total += s.fees;
        return total;
    }

    public void Display()
    {
        Console.WriteLine("Degree: " + name + " | Duration: " + duration +
            " years | Seats Left: " + seatsLeft);
        foreach (Subject s in subjects) s.Display();
    }
}

class Student
{
    public string name;
    public int age;
    public int fscMarks;
    public int ecatMarks;
    public List<string> preferences = new List<string>();
    public string admittedProgram = "";
    public List<Subject> registeredSubjects = new List<Subject>();

    public Student(string n, int a, int fsc, int ecat)
    {
        name = n; age = a; fscMarks = fsc; ecatMarks = ecat;
    }

    public float CalculateMerit()
    {
        return (fscMarks * 0.60f) + (ecatMarks * 0.40f);
    }

    public void AddPreference(string p) { preferences.Add(p); }

    public void RegisterSubject(Subject s)
    {
        foreach (Subject rs in registeredSubjects)
            if (rs.code == s.code) { Console.WriteLine("Subject already registered."); return; }
        registeredSubjects.Add(s);
        Console.WriteLine("Subject " + s.code + " registered for " + name);
    }

    public float CalculateFees()
    {
        float total = 0;
        foreach (Subject s in registeredSubjects) total += s.fees;
        return total;
    }

    public void Display()
    {
        Console.WriteLine(name.PadRight(10) + fscMarks.ToString().PadRight(10) +
            ecatMarks.ToString().PadRight(10) + age);
    }
}

class Program
{
    static List<DegreeProgram> programs = new List<DegreeProgram>();
    static List<Student> students = new List<Student>();
    static List<Student> registeredStudents = new List<Student>();

    static DegreeProgram FindProgram(string name)
    {
        foreach (DegreeProgram dp in programs)
            if (dp.name.ToLower() == name.ToLower()) return dp;
        return null;
    }

    static Student FindStudent(string name)
    {
        foreach (Student s in students)
            if (s.name.ToLower() == name.ToLower()) return s;
        return null;
    }

    static void AddDegreeProgram()
    {
        Console.Write("Enter Degree Name: "); string n = Console.ReadLine();
        Console.Write("Enter Degree Duration: "); int d = int.Parse(Console.ReadLine());
        Console.Write("Enter Seats for Degree: "); int seats = int.Parse(Console.ReadLine());

        DegreeProgram dp = new DegreeProgram(n, d, seats);

        Console.Write("Enter How many Subjects to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Subject Code: "); int code = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Type: "); string t = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: "); int ch = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: "); float f = float.Parse(Console.ReadLine());
            dp.AddSubject(new Subject(code, t, ch, f));
        }

        programs.Add(dp);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void AddStudent()
    {
        Console.Write("Enter Student Name: "); string n = Console.ReadLine();
        Console.Write("Enter Student Age: "); int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Student FSc Marks: "); int fsc = int.Parse(Console.ReadLine());
        Console.Write("Enter Student Ecat Marks: "); int ecat = int.Parse(Console.ReadLine());

        Student s = new Student(n, age, fsc, ecat);

        Console.WriteLine("Available Degree Programs");
        foreach (DegreeProgram dp in programs) Console.WriteLine(dp.name);

        Console.Write("Enter how many preferences to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string pref = Console.ReadLine();
            s.AddPreference(pref);
        }

        students.Add(s);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void GenerateMerit()
    {
        List<Student> sorted = new List<Student>(students);
        sorted.Sort((a, b) => b.CalculateMerit().CompareTo(a.CalculateMerit()));

        foreach (Student s in sorted)
        {
            bool admitted = false;
            foreach (string pref in s.preferences)
            {
                DegreeProgram dp = FindProgram(pref);
                if (dp != null && dp.seatsLeft > 0)
                {
                    dp.seatsLeft--;
                    s.admittedProgram = dp.name;
                    registeredStudents.Add(s);
                    Console.WriteLine(s.name + " got Admission in " + dp.name);
                    admitted = true;
                    break;
                }
            }
            if (!admitted) Console.WriteLine(s.name + " did not get Admission");
        }

        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void ViewRegisteredStudents()
    {
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in registeredStudents) s.Display();
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void ViewStudentsOfProgram()
    {
        Console.Write("Enter Degree Name: "); string name = Console.ReadLine();
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in registeredStudents)
            if (s.admittedProgram.ToLower() == name.ToLower()) s.Display();
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void RegisterSubjects()
    {
        Console.Write("Enter Student Name: "); string name = Console.ReadLine();
        Student s = FindStudent(name);
        if (s == null || s.admittedProgram == "") { Console.WriteLine("Student not admitted."); return; }

        DegreeProgram dp = FindProgram(s.admittedProgram);
        if (dp == null) { Console.WriteLine("Program not found."); return; }

        Console.Write("Enter Subject Code: "); int code = int.Parse(Console.ReadLine());

        foreach (Subject sub in dp.subjects)
        {
            if (sub.code == code)
            {
                s.RegisterSubject(sub);
                Console.WriteLine("Press any key to Continue..");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Subject not found in " + dp.name);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void CalculateFeesAll()
    {
        foreach (Student s in registeredStudents)
        {
            float fees = s.CalculateFees();
            Console.WriteLine(s.name + " | Program: " + s.admittedProgram +
                " | Total Fees: $" + fees.ToString("F2"));
        }
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n************************************");
            Console.WriteLine("                UAMS                ");
            Console.WriteLine("************************************");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) AddDegreeProgram();
            else if (choice == 3) GenerateMerit();
            else if (choice == 4) ViewRegisteredStudents();
            else if (choice == 5) ViewStudentsOfProgram();
            else if (choice == 6) RegisterSubjects();
            else if (choice == 7) CalculateFeesAll();
            else if (choice == 8) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid option.");

        } while (choice != 8);
    }
}
