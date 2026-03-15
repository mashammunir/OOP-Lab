using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                string path = "G:\\OOP 2022\\BootingCSharp\\textfile.txt";
                StreamWriter fileVariable = new StreamWriter(path, true);
                fileVariable.WriteLine("hello");
                fileVariable.Flush();
                fileVariable.Close();
            }
        }
    }

