using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Entities;
namespace Phonebook.Repositories
{
    class ContactsRepository
    {
        public void Add()
        {
          string path = "contacts.txt";
          StreamReader reader = new StreamReader(path);
           try
            {
                Console.Clear();
                Console.Write("Please enter contact name: ");
                Contact userInput = new Contact();
                userInput.ParentUserId = AuthenticationManager.LoggedUser.Id;
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
                    databaseContact.ParentUserId = Int32.Parse(reader.ReadLine());
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

                StreamReader reader2 = new StreamReader(path);
                int idCounter = 1;
                while (!reader2.EndOfStream)
                {
                    databaseContact.Id = Int32.Parse(reader2.ReadLine());
                    databaseContact.ParentUserId = Int32.Parse(reader2.ReadLine());
                    databaseContact.Name = reader2.ReadLine();
                    databaseContact.PhoneNumber = reader2.ReadLine();
                    databaseContact.Email = reader2.ReadLine();
                    if (reader2.ReadLine() == userInput.Email)
                    {
                        Console.WriteLine("A user with the same email already exists! Please try again!");
                        return;
                    }
                    idCounter++;
                }
                userInput.Id = idCounter;
                reader.Close();
                reader2.Close();
                File.AppendAllText(path, "\r\n" + userInput.Id);
                File.AppendAllText(path, "\r\n" + userInput.ParentUserId); //same id as it's owner
                File.AppendAllText(path, "\r\n" + userInput.Name);
                File.AppendAllText(path, "\r\n" + userInput.PhoneNumber);
                File.AppendAllText(path, "\r\n" + userInput.Email);
                StreamReader reader3 = new StreamReader(path);
                string usersInfo = reader3.ReadToEnd().TrimEnd('\r', '\n').TrimStart('\r', '\n');//trailing white space (from the WriteLine) removing
                reader.Close();
                reader3.Close();
                StreamWriter writer = new StreamWriter(path);
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
