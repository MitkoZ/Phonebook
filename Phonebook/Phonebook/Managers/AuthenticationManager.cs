using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Phonebook
{
    class AuthenticationManager
    {
        public static User LoggedUser { get; private set; }
        public static void Authenticate(string usernameInput, string passwordInput)
        {
            User user = null;
            StreamReader reader = new StreamReader("database.txt");
            while (!reader.EndOfStream)
            {
                User u = new User();
                u.Username = reader.ReadLine();
                u.Password = reader.ReadLine();

                if (usernameInput == u.Username && passwordInput == u.Password)
                {
                    user = u;
                    break;
                }
            }
            reader.Close();
            LoggedUser = user;
        }
    }
}
