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
                Console.Write("Please enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();
                AuthenticationManager.Authenticate(username, password);
                if (AuthenticationManager.LoggedUser != null)
                {
                    AdminView adminView = new AdminView();
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
