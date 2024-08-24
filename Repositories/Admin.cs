using System;
using System.Collections.Generic;
using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class Admin
    {
        public static List<User> users = new List<User>();
        static User activeUser;

        public static void SetActiveUser(User user)
        {
            activeUser = user;
        }

        public static void CreateUser(int id, string firstName, string lastName, bool isAdmin)
        {
            ValidateAdminAccess();
            ValidateActiveUser();
            if (id <= 0 || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new InvalidUserException("Invalid user details");
            if (users.Any(u => u.UserID == id))
                throw new DuplicateUserException("A user with the same ID already exists.");
            User user = User.CreateUser(id, firstName, lastName, isAdmin);
            users.Add(user);
        }

        public static void UpdateUser(int id, string firstName, string lastName)
        {
            ValidateAdminAccess();
            ValidateActiveUser();
            var user = GetUser(id);
            user.FirstName = firstName;
            user.LastName = lastName;
        }

        public static User FindUserById(int id)
        {
            return GetUser(id);
        }

        public static void DeleteUser(int id)
        {
            ValidateAdminAccess();
            ValidateActiveUser();
            var user = GetUser(id);
            user.IsActive = false;
        }

        public static List<User> DisplayUsers()
        {
            return users;
        }

        private static void ValidateAdminAccess()
        {
            if (activeUser == null || !activeUser.IsAdmin)
            {
                throw new AdminAccessException("This Operation Can Only be performed by Admin");
            }
        }

        private static void ValidateActiveUser()
        {

            if (!activeUser.IsActive)
            {
                throw new DeActiveUserException("Cannot Perform Operation Admin is DeActivated");
            }
        }

        private static User GetUser(int id)
        {
            var user = users.Find(u => u.UserID == id);
            if (user == null)
            {
                throw new UserNotFoundException("User Not Found");
            }
            if (!user.IsActive)
            {
                throw new DeActiveUserException("User is Deactivated");
            }
            return user;
        }
    }
}
