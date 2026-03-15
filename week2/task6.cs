using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task6
{
    class MUser
    {
        public string Username;
        public string Password;
        public string Role;

        public MUser(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    internal class Program
    {
        static List<MUser> users = new List<MUser>();
        static string filePath = "users.txt";

        static void LoadUsers()
        {
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    users.Add(new MUser(parts[0], parts[1], parts[2]));
                }
            }
        }

        static bool SignUp(string username, string password, string role)
        {
            foreach (var u in users)
            {
                if (u.Username == username) return false;
            }
            MUser newUser = new MUser(username, password, role);
            users.Add(newUser);
            File.AppendAllText(filePath, username + "," + password + "," + role + Environment.NewLine);
            return true;
        }

        static bool SignIn(string username, string password)
        {
            foreach (var u in users)
            {
                if (u.Username == username && u.Password == password) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            LoadUsers();

            while (true)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter Role: ");
                    string role = Console.ReadLine();

                    if (SignUp(username, password, role))
                        Console.WriteLine("Sign Up Successful");
                    else
                        Console.WriteLine("Username already exists");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    if (SignIn(username, password))
                        Console.WriteLine("Sign In Successful");
                    else
                        Console.WriteLine("Invalid Username or Password");
                }
                else if (choice == 3) break;
            }
        }
    }
}