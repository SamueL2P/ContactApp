using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        public List<ContactDetails> ContactDetailsList { get; set; } = new List<ContactDetails>();

        public Contact() { }

        public Contact(int contactID, string firstName, string lastName )
        {
            ContactID = contactID;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }

        public static Contact CreateContact(int id , string firstName, string lastName)
        {
            return new Contact(id, firstName, lastName);
        }

        public override string ToString() {
            return $"\nContact ID : {ContactID}\n" +
                $"Contact First Name : {FirstName}\n" +
                $"Contact Last Name : {LastName}\n" +
                $"Contact Status : {(IsActive ? "Active" : "Inactive")}";
        }
    }
}
