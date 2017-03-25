using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Phonebook.Managers
{
    class UsersManager
    {
        string username;
        string password;
        enum UsersManagerOptions
        {
            Update = 1,
            Delete
        }
        public void Show(string username, string password)
        {
            this.username = username;
            this.password = password;
            Console.WriteLine("Press 1 to change your password");
            Console.WriteLine("Press 2 to delete your account");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case (int)UsersManagerOptions.Update:
                    {
                        Update();
                    }
                    break;

                case
                    (int)UsersManagerOptions.Delete:
                    {
                        Delete();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again! (Press any key to continue)");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }
        public void Add()
        {

        }
        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Old password:");
            string oldPassword = Console.ReadLine();
            if (oldPassword == password)
            {
                Console.WriteLine("New password:");
                string newPassword = Console.ReadLine();
                StreamReader reader = new StreamReader("database.txt");
                StreamWriter writer = new StreamWriter("temp.txt");
                StreamReader reader2 = new StreamReader("database.txt");
                while (!reader.EndOfStream)
                {
                    string username = reader.ReadLine();
                    string password = reader.ReadLine();
                    if (username == this.username && password == oldPassword)
                    {
                        while (!reader2.EndOfStream)
                        {
                            username = reader2.ReadLine();
                            password = reader2.ReadLine();
                            if (username == this.username && password == oldPassword)
                            {
                                writer.WriteLine(this.username);
                                writer.WriteLine(newPassword);
                            }
                            else
                            {
                                writer.WriteLine(username);
                                writer.WriteLine(password);
                            }
                        }
                    }
                }
                reader.Close();
                writer.Close();
                reader2.Close();
                File.Copy("temp.txt", "database.txt", true);
                File.Delete("temp.txt");
                Console.WriteLine("Password changed successfully! Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong password! Press any key to try again!");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        public void Delete()
        {

        }
    }
}
