using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class LoginView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter your username:");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                if (AuthenticationManager.Authenticate(username, password))
                {
                    AdminView adminView = new AdminView(username, password);
                    adminView.ShowMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password! Press any key to try again.");
                    Console.ReadKey(true);
                }

            }

        }
    }
}
