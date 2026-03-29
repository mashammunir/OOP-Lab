using System;
using System.Xml.Linq;

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

    public bool IsEligibleForScholarship(float meritPercentage)
    {
        if (meritPercentage > 80 && isHostelite)
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
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student();
        s1.name = "Ayesha";
        s1.rollNumber = 101;
        s1.cgpa = 3.8f;
        s1.matricMarks = 95;
        s1.fscMarks = 90;
        s1.ecatMarks = 85;
        s1.homeTown = "Lahore";
        s1.isHostelite = true;
        s1.isTakingScholarship = false;

        Student s2 = new Student();
        s2.name = "Sara";
        s2.rollNumber = 102;
        s2.cgpa = 3.2f;
        s2.matricMarks = 80;
        s2.fscMarks = 70;
        s2.ecatMarks = 65;
        s2.homeTown = "Karachi";
        s2.isHostelite = false;
        s2.isTakingScholarship = false;

        Student s3 = new Student();
        s3.name = "Fatima";
        s3.rollNumber = 103;
        s3.cgpa = 3.5f;
        s3.matricMarks = 88;
        s3.fscMarks = 75;
        s3.ecatMarks = 60;
        s3.homeTown = "Multan";
        s3.isHostelite = true;
        s3.isTakingScholarship = false;

        Console.WriteLine("===== Student 1 =====");
        s1.DisplayInfo();
        float merit1 = s1.CalculateMerit();
        Console.WriteLine("Merit: " + merit1);
        Console.WriteLine("Eligible for Scholarship: " + (s1.IsEligibleForScholarship(merit1) ? "Yes" : "No"));

        Console.WriteLine();

        Console.WriteLine("===== Student 2 =====");
        s2.DisplayInfo();
        float merit2 = s2.CalculateMerit();
        Console.WriteLine("Merit: " + merit2);
        Console.WriteLine("Eligible for Scholarship: " + (s2.IsEligibleForScholarship(merit2) ? "Yes" : "No"));

        Console.WriteLine();

        Console.WriteLine("===== Student 3 =====");
        s3.DisplayInfo();
        float merit3 = s3.CalculateMerit();
        Console.WriteLine("Merit: " + merit3);
        Console.WriteLine("Eligible for Scholarship: " + (s3.IsEligibleForScholarship(merit3) ? "Yes" : "No"));
    }
}
