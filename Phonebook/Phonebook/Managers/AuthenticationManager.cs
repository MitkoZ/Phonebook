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
            StreamReader reader = new StreamReader("users.txt");
            try
            {
                User user = null;
                while (!reader.EndOfStream)
                {
                    User u = new User();
                    u.Id = Int32.Parse(reader.ReadLine());
                    u.Username = reader.ReadLine();
                    u.Password = reader.ReadLine();
                    if (usernameInput == u.Username && passwordInput == u.Password)
                    {
                        user = u;
                        break;
                    }
                }
                LoggedUser = user;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}

