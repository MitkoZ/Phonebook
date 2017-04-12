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
        public void Update()//For changing password
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
                StreamReader reader = new StreamReader("users.txt");
                StreamWriter writer = new StreamWriter("temp.txt");
                StreamReader reader2 = new StreamReader("users.txt");
                while (!reader.EndOfStream)
                {
                    User userDatabase = new User();
                    userDatabase.Id = Int32.Parse(reader.ReadLine());
                    userDatabase.Username = reader.ReadLine();
                    userDatabase.Password = reader.ReadLine();
                    userDatabase.FirstName = reader.ReadLine();
                    userDatabase.LastName = reader.ReadLine();
                    if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == oldPassword)
                    {
                        while (!reader2.EndOfStream)
                        {
                            userDatabase.Id = Int32.Parse(reader2.ReadLine());
                            userDatabase.Username = reader2.ReadLine();
                            userDatabase.Password = reader2.ReadLine();
                            userDatabase.FirstName = reader2.ReadLine();
                            userDatabase.LastName = reader2.ReadLine();
                            if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == oldPassword)
                            {
                                writer.WriteLine(userDatabase.Id);
                                writer.WriteLine(AuthenticationManager.LoggedUser.Username);
                                writer.WriteLine(newPassword);
                                writer.WriteLine(userDatabase.FirstName);
                                writer.WriteLine(userDatabase.LastName);
                            }
                            else
                            {
                                writer.WriteLine(userDatabase.Id);
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
                StreamReader reader3 = new StreamReader("temp.txt");
                string usersInfo = reader3.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
                reader3.Close();
                File.Delete("temp.txt");
                File.AppendAllText("temp.txt", usersInfo);
                File.Copy("temp.txt", "users.txt", true);
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
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Please write your password to verify the deletion:");
            string inputPassword = Console.ReadLine();
            User userDatabase = new User();
            if (inputUsername == AuthenticationManager.LoggedUser.Username && inputPassword == AuthenticationManager.LoggedUser.Password)//verifying
            {
                StreamReader reader = new StreamReader("users.txt");
                StreamWriter writer = new StreamWriter("temp.txt");
                bool isDeleted = false;
                while (!reader.EndOfStream)
                {
                    userDatabase.Id = Int32.Parse(reader.ReadLine());
                    userDatabase.Username = reader.ReadLine();
                    userDatabase.Password = reader.ReadLine();
                    userDatabase.FirstName = reader.ReadLine();
                    userDatabase.LastName = reader.ReadLine();
                    if (userDatabase.Username == AuthenticationManager.LoggedUser.Username && userDatabase.Password == AuthenticationManager.LoggedUser.Password)
                    {
                        isDeleted = true;
                        continue;
                    }
                    int idDecrease = 0;
                    if (isDeleted)
                    {
                        idDecrease = 1;
                    }
                    writer.WriteLine(userDatabase.Id - idDecrease);
                    writer.WriteLine(userDatabase.Username);
                    writer.WriteLine(userDatabase.Password);
                    writer.WriteLine(userDatabase.FirstName);
                    writer.WriteLine(userDatabase.LastName);
                }
                writer.Close();
                reader.Close();
                StreamReader reader2 = new StreamReader("temp.txt");
                StreamWriter writer2 = new StreamWriter("users.txt");
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
