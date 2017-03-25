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
        public UsersManager(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public UsersManager()
        {

        }
        enum UsersManagerOptions
        {
            Update = 1,
            Delete
        }
        public void Show()
        {
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

                case (int)UsersManagerOptions.Delete:
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
        public void Add()//For register
        {
            Console.Clear();
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            if (username=="")
            {
                Console.WriteLine("Invalid username!");
                return;
            }
            StreamReader reader = new StreamReader("database.txt");
            while (!reader.EndOfStream)
            {
                
                if (reader.ReadLine()==username)
                {
                    Console.WriteLine("A user with your username already exists! Please try another one!");
                    return;
                }
            }
            reader.Close();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            if (password=="")
            {
                Console.WriteLine("Invalid password!");
                return;
            }
            File.AppendAllText("database.txt", "\r\n"+username);
            File.AppendAllText("database.txt", "\r\n"+password);
            Console.WriteLine("Registration complete!");
        }
        public void Update()//For changing password
        {
            Console.Clear();
            Console.WriteLine("Old password:");
            string oldPassword = Console.ReadLine();
            if (oldPassword == password)
            {
                Console.WriteLine("New password:");
                string newPassword = Console.ReadLine();
                if (newPassword=="")
                {
                    Console.WriteLine("Invalid password");
                    Console.ReadKey(true);
                    return;
                }
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
            }
            else
            {
                Console.WriteLine("Wrong password! Press any key to try again!");
            }
        }
        public void Delete()//For deleting an account
        {
            Console.Clear();
            Console.WriteLine("Please write your username to verify the deletion:");
            string username=Console.ReadLine();
            Console.WriteLine("Please write your password to verify the deletion:");
            string password = Console.ReadLine();
            if (username==this.username && password==this.password)//verifying
            {
                StreamReader reader = new StreamReader("database.txt");
                StreamWriter writer = new StreamWriter("temp.txt");
                while (!reader.EndOfStream)
                {
                    username = reader.ReadLine();
                    password = reader.ReadLine();
                    if (username==this.username && password==this.password)
                    {
                        continue;
                    }
                    writer.WriteLine(username);
                    writer.WriteLine(password);
                    
                }
                reader.Close();
                writer.Close();
                File.Copy("temp.txt", "database.txt", true);
                File.Delete("temp.txt");
                Console.WriteLine("Account deleted successfully!");
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }
            

        }
    }
}
