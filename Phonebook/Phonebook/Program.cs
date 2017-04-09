using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Views;
namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            FrontView frontView = new FrontView();
            Console.ReadKey(true);
        }
    }
}
