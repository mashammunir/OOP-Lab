using System;

class Student
{
    public string name;
    public int rollNumber;
    public float cgpa;
    public int matricMarks;
    public int fscMarks;
    public int ecatMarks;
    public string homeTown;
    public bool isHostelite;
    public bool isTakingScholarship;

    public float CalculateMerit()
    {
        return (fscMarks * 0.60f) + (ecatMarks * 0.40f);
    }

    public bool CheckScholarship()
    {
        if (CalculateMerit() > 80 && isHostelite)
        {
            return true;
        }
        return false;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Roll Number: " + rollNumber);
        Console.WriteLine("CGPA: " + cgpa);
        Console.WriteLine("Matric Marks: " + matricMarks);
        Console.WriteLine("FSC Marks: " + fscMarks);
        Console.WriteLine("ECAT Marks: " + ecatMarks);
        Console.WriteLine("Home Town: " + homeTown);
        Console.WriteLine("Hostelite: " + (isHostelite ? "Yes" : "No"));
        Console.WriteLine("Merit: " + CalculateMerit());
        Console.WriteLine("Eligible for Scholarship: " + (CheckScholarship() ? "Yes" : "No"));
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student();

        s.name = "Ayesha";
        s.rollNumber = 101;
        s.cgpa = 3.5f;
        s.matricMarks = 90;
        s.fscMarks = 85;
        s.ecatMarks = 78;
        s.homeTown = "Lahore";
        s.isHostelite = true;
        s.isTakingScholarship = false;

        s.DisplayInfo();
    }
}