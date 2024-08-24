using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Repositories;

namespace ContactApp.ViewControllers
{
    internal class UserStore
    {
        public static void DisplayMenu()
        {
            while (true) {
                Console.WriteLine("=======Welcome to Contact App by Samuel=======");
                Console.WriteLine("Enter Your User Id ");
                int userId = Convert.ToInt32(Console.ReadLine());
                UserRepository.CheckUser(userId);
            }
        }
    }
}
