using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Managers;
using Phonebook.Repositories;
namespace Phonebook.Views
{
    class FrontView
    {
        public FrontView()
        {
            Console.WriteLine("[1] Login:");
            Console.WriteLine("[2] Register:");
            int choice=Int32.Parse(Console.ReadLine());
            InitialMenuEnum c = (InitialMenuEnum)choice;
            if (c == InitialMenuEnum.Login)
            {
                LoginView loginView = new LoginView();
                loginView.Show();
            }
            else if (c == InitialMenuEnum.Register)
            {
                GuestRepository guestRepository = new GuestRepository();
                guestRepository.Add();
            }
            else
            {
                Console.WriteLine("Invalid choice! Please try again!");
            }
        }
    }
}
