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
        public void Add()//For register
        {
            Console.Clear();
            Console.Write("Please enter your username: ");
            User userInput = new User();
            userInput.Username = Console.ReadLine();
            if (userInput.Username == "")
            {
                Console.WriteLine("Invalid username!");
                return;
            }
            StreamReader reader = new StreamReader("users.txt");
            while (!reader.EndOfStream)
            {
                if (reader.ReadLine() == userInput.Username)
                {
                    Console.WriteLine("A user with your username already exists! Please try another one!");
                    return;
                }
                for (int i = 0; i < 4; i++) //discarding the next four lines of information(password, firstname, lastname)
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
            int counter = 0;
            StreamReader reader2 = new StreamReader("users.txt");
            while (!reader2.EndOfStream)//id
            {
                counter++;
                reader2.ReadLine();
            }
            reader2.Close();
            userInput.Id = (counter / 5) + 1;
            File.AppendAllText("users.txt", "\r\n" + userInput.Id);
            File.AppendAllText("users.txt", "\r\n" + userInput.Username);
            File.AppendAllText("users.txt", "\r\n" + userInput.Password);
            File.AppendAllText("users.txt", "\r\n" + userInput.FirstName);
            File.AppendAllText("users.txt", "\r\n" + userInput.LastName);
            StreamReader reader3 = new StreamReader("users.txt");
            string usersInfo = reader3.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
            reader3.Close();
            StreamWriter writer2 = new StreamWriter("users.txt");
            writer2.Write(usersInfo);
            writer2.Close();
            Console.WriteLine("Registration complete!");
        }
    }
}
