using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Models
{
    internal class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public User() { }

        public User(int userID, string firstName, string lastName, bool isAdmin)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            IsActive = true;
        }

        public static User CreateUser(int id , string firstName, string lastName, bool isAdmin)
        {
            return new User(id, firstName, lastName, isAdmin);
        }

        public override string ToString() {
            return $"User Id : {UserID}\n" +
                $"User FirstName : {FirstName}\n" +
                $"User LastName : {LastName}\n" +
                $"User Role : {(IsAdmin ? "Admin":"Staff")}\n" +
                $"User Status : {(IsActive ? "Active" : "Inactive")}";
        }
    }
}
