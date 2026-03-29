using System;
using System.Collections.Generic;

// ==================== BL CLASSES ====================

class Subject
{
    public string code;
    public string subjectType;
    public int creditHours;
    public int subjectFee;

    public Subject(string code, string type, int creditHours, int subjectFees)
    {
        this.code = code;
        this.subjectType = type;
        this.creditHours = creditHours;
        this.subjectFee = subjectFees;
    }

    public void Display()
    {
        Console.WriteLine("  Code: " + code + " | Type: " + subjectType +
            " | Credit Hours: " + creditHours + " | Fee: " + subjectFee);
    }
}

class DegreeProgram
{
    public string title;
    public float duration;
    public int seats;
    public int seatsLeft;
    public List<Subject> subjects = new List<Subject>();

    public DegreeProgram(string degreeName, float degreeDuration, int seats)
    {
        this.title = degreeName;
        this.duration = degreeDuration;
        this.seats = seats;
        this.seatsLeft = seats;
    }

    public bool IsSubjectExists(Subject sub)
    {
        foreach (Subject s in subjects)
            if (s.code == sub.code) return true;
        return false;
    }

    public void AddSubject(Subject s)
    {
        if (IsSubjectExists(s)) { Console.WriteLine("Subject already exists."); return; }
        if (CalculateCreditHours() + s.creditHours > 20)
        { Console.WriteLine("Cannot add. Program exceeds 20 credit hours."); return; }
        subjects.Add(s);
    }

    public int CalculateCreditHours()
    {
        int total = 0;
        foreach (Subject s in subjects) total += s.creditHours;
        return total;
    }
}

class Student
{
    public string name;
    public int age;
    public double fscMarks;
    public double ecatMarks;
    public float merit;
    public List<DegreeProgram> preferences = new List<DegreeProgram>();
    public string admittedProgram = "";
    public List<Subject> registeredSubjects = new List<Subject>();

    public Student(string name, int age, double fscMarks, double ecatMarks,
        List<DegreeProgram> preferences)
    {
        this.name = name;
        this.age = age;
        this.fscMarks = fscMarks;
        this.ecatMarks = ecatMarks;
        this.preferences = preferences;
    }

    public void CalculateMerit()
    {
        merit = (float)((fscMarks * 0.60) + (ecatMarks * 0.40));
    }

    public void RegStudentSubject(Subject s)
    {
        if (admittedProgram == "") { Console.WriteLine("Student not admitted yet."); return; }
        if (GetCreditHours() + s.creditHours > 9)
        { Console.WriteLine("Cannot register. Exceeds 9 credit hours limit."); return; }
        foreach (Subject rs in registeredSubjects)
            if (rs.code == s.code) { Console.WriteLine("Subject already registered."); return; }
        registeredSubjects.Add(s);
        Console.WriteLine("Subject " + s.code + " registered for " + name);
    }

    public int GetCreditHours()
    {
        int total = 0;
        foreach (Subject s in registeredSubjects) total += s.creditHours;
        return total;
    }

    public float CalculateFee()
    {
        float total = 0;
        foreach (Subject s in registeredSubjects) total += s.subjectFee;
        return total;
    }
}

// ==================== DL CLASSES ====================

class SubjectDL
{
    public List<Subject> subjects = new List<Subject>();

    public void Add(Subject s) { subjects.Add(s); }

    public Subject FindByCode(string code)
    {
        foreach (Subject s in subjects)
            if (s.code == code) return s;
        return null;
    }
}

class DegreeProgramDL
{
    public List<DegreeProgram> programs = new List<DegreeProgram>();

    public void Add(DegreeProgram dp) { programs.Add(dp); }

    public DegreeProgram FindByTitle(string title)
    {
        foreach (DegreeProgram dp in programs)
            if (dp.title.ToLower() == title.ToLower()) return dp;
        return null;
    }
}

class StudentDL
{
    public List<Student> students = new List<Student>();
    public List<Student> registeredStudents = new List<Student>();

    public void Add(Student s) { students.Add(s); }

    public void AddRegistered(Student s) { registeredStudents.Add(s); }

    public Student FindByName(string name)
    {
        foreach (Student s in students)
            if (s.name.ToLower() == name.ToLower()) return s;
        return null;
    }
}

// ==================== UI CLASSES ====================

class SubjectUI
{
    SubjectDL dl;
    public SubjectUI(SubjectDL dl) { this.dl = dl; }

    public Subject InputSubject()
    {
        Console.Write("Enter Subject Code: "); string code = Console.ReadLine();
        Console.Write("Enter Subject Type: "); string type = Console.ReadLine();
        Console.Write("Enter Subject Credit Hours: "); int ch = int.Parse(Console.ReadLine());
        Console.Write("Enter Subject Fees: "); int fee = int.Parse(Console.ReadLine());
        Subject s = new Subject(code, type, ch, fee);
        dl.Add(s);
        return s;
    }
}

class DegreeProgramUI
{
    DegreeProgramDL dl;
    SubjectUI subjectUI;

    public DegreeProgramUI(DegreeProgramDL dl, SubjectUI subjectUI)
    {
        this.dl = dl;
        this.subjectUI = subjectUI;
    }

    public void AddDegreeProgram()
    {
        Console.Write("Enter Degree Name: "); string name = Console.ReadLine();
        Console.Write("Enter Degree Duration: "); float dur = float.Parse(Console.ReadLine());
        Console.Write("Enter Seats for Degree: "); int seats = int.Parse(Console.ReadLine());

        DegreeProgram dp = new DegreeProgram(name, dur, seats);

        Console.Write("Enter How many Subjects to Enter: ");
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            Subject s = subjectUI.InputSubject();
            dp.AddSubject(s);
        }

        dl.Add(dp);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void DisplayAll()
    {
        foreach (DegreeProgram dp in dl.programs)
        {
            Console.WriteLine("Program: " + dp.title + " | Duration: " + dp.duration +
                " | Seats Left: " + dp.seatsLeft);
            foreach (Subject s in dp.subjects) s.Display();
        }
    }
}

class StudentUI
{
    StudentDL studentDL;
    DegreeProgramDL programDL;

    public StudentUI(StudentDL studentDL, DegreeProgramDL programDL)
    {
        this.studentDL = studentDL;
        this.programDL = programDL;
    }

    public void AddStudent()
    {
        Console.Write("Enter Student Name: "); string name = Console.ReadLine();
        Console.Write("Enter Student Age: "); int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Student FSc Marks: "); double fsc = double.Parse(Console.ReadLine());
        Console.Write("Enter Student Ecat Marks: "); double ecat = double.Parse(Console.ReadLine());

        Console.WriteLine("Available Degree Programs");
        foreach (DegreeProgram dp in programDL.programs) Console.WriteLine(dp.title);

        Console.Write("Enter how many preferences to Enter: ");
        int count = int.Parse(Console.ReadLine());

        List<DegreeProgram> prefs = new List<DegreeProgram>();
        for (int i = 0; i < count; i++)
        {
            string pref = Console.ReadLine();
            DegreeProgram dp = programDL.FindByTitle(pref);
            if (dp != null) prefs.Add(dp);
            else Console.WriteLine("Program not found: " + pref);
        }

        studentDL.Add(new Student(name, age, fsc, ecat, prefs));
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void GenerateMerit()
    {
        List<Student> sorted = new List<Student>(studentDL.students);
        foreach (Student s in sorted) s.CalculateMerit();
        sorted.Sort((a, b) => b.merit.CompareTo(a.merit));

        foreach (Student s in sorted)
        {
            bool admitted = false;
            foreach (DegreeProgram dp in s.preferences)
            {
                if (dp.seatsLeft > 0)
                {
                    dp.seatsLeft--;
                    s.admittedProgram = dp.title;
                    studentDL.AddRegistered(s);
                    Console.WriteLine(s.name + " got Admission in " + dp.title);
                    admitted = true;
                    break;
                }
            }
            if (!admitted) Console.WriteLine(s.name + " did not get Admission");
        }

        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void ViewRegisteredStudents()
    {
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in studentDL.registeredStudents)
            Console.WriteLine(s.name.PadRight(10) + s.fscMarks.ToString().PadRight(10) +
                s.ecatMarks.ToString().PadRight(10) + s.age);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void ViewStudentsOfProgram()
    {
        Console.Write("Enter Degree Name: "); string name = Console.ReadLine();
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in studentDL.registeredStudents)
            if (s.admittedProgram.ToLower() == name.ToLower())
                Console.WriteLine(s.name.PadRight(10) + s.fscMarks.ToString().PadRight(10) +
                    s.ecatMarks.ToString().PadRight(10) + s.age);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void RegisterSubjects()
    {
        Console.Write("Enter Student Name: "); string name = Console.ReadLine();
        Student st = studentDL.FindByName(name);
        if (st == null || st.admittedProgram == "")
        { Console.WriteLine("Student not admitted."); return; }

        DegreeProgram dp = programDL.FindByTitle(st.admittedProgram);
        if (dp == null) { Console.WriteLine("Program not found."); return; }

        Console.Write("Enter Subject Code: "); string code = Console.ReadLine();
        foreach (Subject s in dp.subjects)
        {
            if (s.code == code) { st.RegStudentSubject(s); return; }
        }
        Console.WriteLine("Subject not found in " + dp.title);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    public void CalculateFeesAll()
    {
        foreach (Student s in studentDL.registeredStudents)
            Console.WriteLine(s.name + " | Program: " + s.admittedProgram +
                " | Credit Hours: " + s.GetCreditHours() +
                " | Total Fee: " + s.CalculateFee());
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }
}

// ==================== ConsoleUtility ====================

class ConsoleUtility
{
    public static void ShowMainMenu()
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
    }
}

// ==================== DRIVER ====================

class Program
{
    static void Main()
    {
        SubjectDL subjectDL = new SubjectDL();
        DegreeProgramDL programDL = new DegreeProgramDL();
        StudentDL studentDL = new StudentDL();

        SubjectUI subjectUI = new SubjectUI(subjectDL);
        DegreeProgramUI programUI = new DegreeProgramUI(programDL, subjectUI);
        StudentUI studentUI = new StudentUI(studentDL, programDL);

        int choice;
        do
        {
            ConsoleUtility.ShowMainMenu();
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) studentUI.AddStudent();
            else if (choice == 2) programUI.AddDegreeProgram();
            else if (choice == 3) studentUI.GenerateMerit();
            else if (choice == 4) studentUI.ViewRegisteredStudents();
            else if (choice == 5) studentUI.ViewStudentsOfProgram();
            else if (choice == 6) studentUI.RegisterSubjects();
            else if (choice == 7) studentUI.CalculateFeesAll();
            else if (choice == 8) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid option.");

        } while (choice != 8);
    }
}
```

**Layered structure explained:**
```
BL(Business Logic)  → Subject, DegreeProgram, Student
DL  (Data Layer)      → SubjectDL, DegreeProgramDL, StudentDL
UI  (User Interface)  → SubjectUI, DegreeProgramUI, StudentUI
Utility               → ConsoleUtility (main menu)
Driver                → Program.Main()