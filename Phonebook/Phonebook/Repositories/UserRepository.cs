using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Repositories
{
    class UserRepository
    {
        public static void Update()//For changing password
        {
            Console.Clear();
            Console.WriteLine("Old password:");
            string oldPassword = Console.ReadLine();
            if (oldPassword == AuthenticationManager.LoggedUser.Password)
            {
                Console.WriteLine("New password:");
                string newPassword = Console.ReadLine();
                if (newPassword == "")
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
                    User userDatabase = new User();
                    userDatabase.Username = reader.ReadLine();
                    userDatabase.Password = reader.ReadLine();
                    userDatabase.FirstName = reader.ReadLine();
                    userDatabase.LastName = reader.ReadLine();
                    if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == oldPassword)
                    {
                        while (!reader2.EndOfStream)
                        {
                            userDatabase.Username = reader2.ReadLine();
                            userDatabase.Password = reader2.ReadLine();
                            userDatabase.FirstName = reader2.ReadLine();
                            userDatabase.LastName = reader2.ReadLine();
                            if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == oldPassword)
                            {
                                writer.WriteLine(AuthenticationManager.LoggedUser.Username);
                                writer.WriteLine(newPassword);
                                writer.WriteLine(userDatabase.FirstName);
                                writer.WriteLine(userDatabase.LastName);
                            }
                            else
                            {
                                writer.WriteLine(userDatabase.Username);
                                writer.WriteLine(userDatabase.Password);
                                writer.WriteLine(userDatabase.FirstName);
                                writer.WriteLine(userDatabase.LastName);
                            }
                        }
                    }
                }
                reader.Close();
                writer.Close();
                reader2.Close();
                // code for white space trimming needs to be inserted here
                File.Copy("temp.txt", "database.txt", true);
                File.Delete("temp.txt");
                Console.WriteLine("Password changed successfully! Press any key to continue");
            }
            else
            {
                Console.WriteLine("Wrong password! Press any key to try again!");
            }
        }

        public static void Delete()//For deleting an account
        {
            Console.Clear();
            Console.WriteLine("Please write your username to verify the deletion:");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Please write your password to verify the deletion:");
            string inputPassword = Console.ReadLine();
            User userDatabase = new User();
            if (inputUsername == AuthenticationManager.LoggedUser.Username && inputPassword == AuthenticationManager.LoggedUser.Password)//verifying
            {
                StreamReader reader = new StreamReader("database.txt");
                StreamWriter writer = new StreamWriter("temp.txt");
                while (!reader.EndOfStream)
                {
                    userDatabase.Username = reader.ReadLine();
                    userDatabase.Password = reader.ReadLine();
                    userDatabase.FirstName = reader.ReadLine();
                    userDatabase.LastName = reader.ReadLine();
                    if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == AuthenticationManager.LoggedUser.Password)
                    {
                        continue;
                    }
                    writer.WriteLine(userDatabase.Username);
                    writer.WriteLine(userDatabase.Password);
                    writer.WriteLine(userDatabase.FirstName);
                    writer.WriteLine(userDatabase.LastName);
                }
                writer.Close();
                reader.Close();
                StreamReader reader2 = new StreamReader("temp.txt");
                StreamWriter writer2 = new StreamWriter("database.txt");
                string usersInfo = reader2.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
                writer2.Write(usersInfo);
                writer2.Close();
                reader2.Close();
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
