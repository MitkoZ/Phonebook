using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Entities;
namespace Phonebook.Repositories
{
    class ContactsRepository:BaseRepository
    {
        public override void Add()
        {
          StreamReader reader = new StreamReader("contacts.txt");
           try
            {
                Console.Clear();
                Console.Write("Please enter contact name: ");
                Contact userInput = new Contact();
                userInput.Name = Console.ReadLine();
                if (userInput.Name == "")
                {
                    Console.WriteLine("Invalid name!");
                    return;
                }
                Console.Write("Please enter contact phone number:");
                userInput.PhoneNumber = Console.ReadLine();
                if (userInput.PhoneNumber == "")
                {
                    Console.WriteLine("Invalid password!");
                    return;
                }

                Contact databaseContact = new Contact();
                while (!reader.EndOfStream)
                {
                    databaseContact.Id = Int32.Parse(reader.ReadLine());
                    databaseContact.Name = reader.ReadLine();
                    databaseContact.PhoneNumber = reader.ReadLine();
                    databaseContact.Email = reader.ReadLine();
                    if (databaseContact.PhoneNumber == userInput.PhoneNumber)
                    {
                        Console.WriteLine("A user with the same phone number already exists! Please try again!");
                        return;
                    }
                }
                Console.Write("Please enter your e-mail: ");
                userInput.Email = Console.ReadLine();
                if (userInput.PhoneNumber == "")
                {
                    Console.WriteLine("Invalid e-mail!");
                    return;
                }

                StreamReader reader2 = new StreamReader("contacts.txt");
                while (!reader2.EndOfStream)
                {
                    databaseContact.Id = Int32.Parse(reader2.ReadLine());
                    databaseContact.Name = reader2.ReadLine();
                    databaseContact.PhoneNumber = reader2.ReadLine();
                    databaseContact.Email = reader2.ReadLine();
                    if (reader2.ReadLine() == userInput.Email)
                    {
                        Console.WriteLine("A user with the same email already exists! Please try again!");
                        return;
                    }
                }
                reader.Close();
                reader2.Close();
                File.AppendAllText("contacts.txt", "\r\n" + AuthenticationManager.LoggedUser.Id); //same id as it's owner
                File.AppendAllText("contacts.txt", "\r\n" + userInput.Name);
                File.AppendAllText("contacts.txt", "\r\n" + userInput.PhoneNumber);
                File.AppendAllText("contacts.txt", "\r\n" + userInput.Email);
                StreamReader reader3 = new StreamReader("contacts.txt");
                string usersInfo = reader3.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
                reader.Close();
                reader3.Close();
                StreamWriter writer = new StreamWriter("contacts.txt");
                writer.Write(usersInfo);
                writer.Close();
                Console.WriteLine("Contact added!");
            }
            finally
            {
                reader.Close();
            }
            
        }
    }
}
