using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Managers;
namespace Phonebook.Views
{
    class FrontView
    {
        public FrontView()
        {
            Console.WriteLine("Press 1 to login:");
            Console.WriteLine("Press 2 to register:");
            int choice=Int32.Parse(Console.ReadLine());
            if (choice==1)
            {
                LoginView loginView = new LoginView();
                loginView.Show();
            }
            else if (choice==2)
            {
                UsersManager userManager = new UsersManager();
                userManager.Add();        
            }
        }
        
    }
}
