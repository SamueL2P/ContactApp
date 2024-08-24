using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ContactApp.Exceptions;
using ContactApp.Repositories;

namespace ContactApp.ViewControllers
{
    internal class AdminStore
    {
        public static void Display()
        {
            while (true)
            {
                Console.WriteLine("\n==========Admin Panel==============\n" +
                   "\n1. Create User\n" +
                   "2. Update User\n" +
                   "3. Delete User\n" +
                   "4. Display All Users\n" +
                   "5. Find User By Id\n" +
                   "6. Logout");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        static void DoTask(int choice)
        {
            try
            {
                switch (choice)
                {

                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        DisplayUsers();
                        break;
                    case 5:
                        Find();
                        break;
                    case 6:
                        UserStore.DisplayMenu();
                        break;
                }
            }
            catch (AdminAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InvalidUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DuplicateUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DeActiveUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(EmptyListException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void Add()
        {
            Console.WriteLine("Enter User Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User First Name  ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter User Last Name  ");
            string last = Console.ReadLine();
            Console.WriteLine("Is user Admin ? yes or no");
            string adminInput = Console.ReadLine();
            bool admin = false;
            if(adminInput == "yes") 
                admin = true;
            try
            {
                Admin.CreateUser(id, first, last, admin);
                Console.WriteLine("\nUser Created Successully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Update()
        {
            Console.WriteLine("Enter User Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter updated FirstName:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter updated LastName:");
            string last = Console.ReadLine();
            try
            {
                Admin.UpdateUser(id, first, last);
                Console.WriteLine("\nUser Updated Successully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Delete()
        {
            Console.WriteLine("Enter User Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                Admin.DeleteUser(id);
                Console.WriteLine("\nUser Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayUsers()
        {
            try
            {
                var users = Admin.DisplayUsers();
                foreach (var user in users)
                {
                    Console.WriteLine("\n=======================");
                    Console.WriteLine(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Find()
        {

            Console.WriteLine("Enter User Id :");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var user = Admin.FindUserById(id);
                if (user != null && user.IsActive == true)
                {
                    Console.WriteLine("\n======================");
                    Console.WriteLine(user);
                }
                else
                {
                    Console.WriteLine("\nUser Not Found");
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

    }
}

