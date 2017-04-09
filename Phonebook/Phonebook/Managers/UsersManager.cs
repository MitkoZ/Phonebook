using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Phonebook.Repositories;

namespace Phonebook.Managers
{
    class UsersManager
    {
        public void Show()
        {
            Console.WriteLine("[1] Change your password");
            Console.WriteLine("[2] Delete your account");
            int choice = Int32.Parse(Console.ReadLine());
            UsersManagerOptions option = (UsersManagerOptions)choice;
            switch (option)
            {
                case UsersManagerOptions.Update:
                    {
                        UserRepository.Update();
                    }
                    break;

                case UsersManagerOptions.Delete:
                    {
                        UserRepository.Delete();
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
