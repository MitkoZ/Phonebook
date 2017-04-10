using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Repositories;

namespace Phonebook.Managers
{
    class UsersManager
    {
        public void Show()
        {
            Console.WriteLine("[1] Change your password");
            Console.WriteLine("[2] Delete your account");
            Console.WriteLine("[3] Add contact");
            int choice = Int32.Parse(Console.ReadLine());
            UsersManagerOptions option = (UsersManagerOptions)choice;
            UserRepository userRepository = new UserRepository();
            ContactsRepository contactRepository = new ContactsRepository();
            switch (option)
            {
                case UsersManagerOptions.Update:
                    {
                        userRepository.Update();
                    }
                    break;

                case UsersManagerOptions.Delete:
                    {
                        userRepository.Delete();
                    }
                    break;

                case UsersManagerOptions.AddContact:
                    {
                        contactRepository.Add();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again! (Press any key to continue)");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }
     }
  }
