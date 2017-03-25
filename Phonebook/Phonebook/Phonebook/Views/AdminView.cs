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
        private string username;
        private string password;
        public AdminView(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void ShowMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Hello, {0}!", username);
                Console.WriteLine("Press 1 for user management");
                Console.WriteLine("Press X to exit");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x")
                {
                    return;
                }
                else if (Int32.Parse(choice) == 1)
                {
                    Console.Clear();
                    UsersManager userManager = new UsersManager();
                    userManager.Show(username, password);
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
