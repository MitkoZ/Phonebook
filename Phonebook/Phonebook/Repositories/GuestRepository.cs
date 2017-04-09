using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Repositories
{
    class GuestRepository
    {
        public static void Add()//For register
        {
            Console.Clear();
            Console.Write("Please enter your username: ");
            User userInput = new User();
            userInput.Username= Console.ReadLine();
            if (userInput.Username == "")
            {
                Console.WriteLine("Invalid username!");
                return;
            }
            StreamReader reader = new StreamReader("database.txt");
            while (!reader.EndOfStream)
            {
                if (reader.ReadLine() == userInput.Username)
                {
                    Console.WriteLine("A user with your username already exists! Please try another one!");
                    return;
                }
                for (int i = 0; i < 3; i++) //discarding the next four lines of information(password, firstname, lastname)
                {
                    reader.ReadLine();
                }
            }
            reader.Close();
            Console.Write("Please enter your password: ");
            userInput.Password = Console.ReadLine();
            if (userInput.Password == "")
            {
                Console.WriteLine("Invalid password!");
                return;
            }
            Console.Write("Please enter your first name: ");
            userInput.FirstName = Console.ReadLine();
            Console.Write("Please enter you last name: ");
            userInput.LastName = Console.ReadLine();
            File.AppendAllText("database.txt", "\r\n" + userInput.Username);
            File.AppendAllText("database.txt", "\r\n" + userInput.Password);
            File.AppendAllText("database.txt", "\r\n" + userInput.FirstName);
            File.AppendAllText("database.txt", "\r\n" + userInput.LastName);
            StreamReader reader2 = new StreamReader("database.txt");
            string usersInfo = reader2.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
            reader2.Close();
            StreamWriter writer2 = new StreamWriter("database.txt");
            writer2.Write(usersInfo);
            writer2.Close();
            Console.WriteLine("Registration complete!");
        }
    }
}
