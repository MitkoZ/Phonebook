using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Managers;
namespace Phonebook
{
    class AdminView
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello, {0}!", AuthenticationManager.LoggedUser.Username);
                Console.WriteLine("[1] User Management");
                Console.WriteLine("[X] Exit");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x")
                {
                    return;
                }
                else if (Int32.Parse(choice) == 1)
                {
                    Console.Clear();
                    UsersManager userManager = new UsersManager();
                    userManager.Show();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again! (Press any key to continue)");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}
