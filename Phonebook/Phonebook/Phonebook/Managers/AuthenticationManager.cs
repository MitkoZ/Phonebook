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
        public static bool Authenticate(string usernameInput, string passwordInput)
        {
            StreamReader reader = new StreamReader("database.txt");

            while (!reader.EndOfStream)
            {
                string username = reader.ReadLine();//from the database
                string password = reader.ReadLine();//from the database
                if (usernameInput == username && passwordInput == password)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
