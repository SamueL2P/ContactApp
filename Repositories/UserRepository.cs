using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.ViewControllers;

namespace ContactApp.Repositories
{
    internal class UserRepository
    {

        public static void CheckUser(int userId)
        {
            var user = Admin.users.Find(u => u.UserID == userId);

            if (user == null)
            {
                Console.WriteLine("User ID does not exist.");
                return;
            }

            if (!user.IsActive)
            {
                Console.WriteLine("User is not active.");
                return;
            }   

            if (user.IsAdmin)
            {
                Admin.SetActiveUser(user);
                AdminStore.Display();

            }
            else
            {
                Staff.SetActiveUser(user);
                StaffStore.Display();
            }
        }
    }
}
