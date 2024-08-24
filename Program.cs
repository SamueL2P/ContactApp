using ContactApp.Models;
using ContactApp.Repositories;
using ContactApp.ViewControllers;

namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User admin = new User
            {
                UserID = 1,
                FirstName = "Samuel",
                LastName = "Padmadan",
                IsAdmin = true
            };

            User staff = new User
            {
                UserID = 2,
                FirstName = "Saroj",
                LastName = "Panda",
                IsAdmin = false
            };

            Admin.users.Add(admin);
            Admin.users.Add(staff);

            UserStore.DisplayMenu();

           
        }
    }
}
