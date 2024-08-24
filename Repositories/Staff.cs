using System;
using System.Collections.Generic;
using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class Staff
    {
        static User activeUser;

        public static void SetActiveUser(User user)
        {
            activeUser = user;
        }

        public static void CreateContact(int id, string firstName, string lastName)
        {
            ValidateActiveUser();
            if (id <= 0 || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new InvalidContactException("Invalid contact details.");
            if (activeUser.Contacts.Any(c => c.ContactID == id))
                throw new DuplicateContactException("A Contact with the same ID already exists.");
            Contact contact = Contact.CreateContact(id, firstName, lastName);
            activeUser.Contacts.Add(contact);
            Console.WriteLine("Staff created.");
        }

        public static Contact FindContactById(int id)
        {
            return GetContact(id);
        }

        public static void UpdateContact(int id, string firstName, string lastName)
        {
            var contact = GetContact(id);
            contact.FirstName = firstName;
            contact.LastName = lastName;
        }

        public static void DeleteContact(int id)
        {
            var contact = GetContact(id);
            contact.IsActive = false;
        }

        public static List<Contact> DisplayContacts()
        {
            ValidateActiveUser();
            if (activeUser.Contacts.Count == 0)
            {
                throw new EmptyListException("Contact List is Empty");
            }
            return activeUser.Contacts;
        }

        public static void CreateContactDetail(int contactId, int cdId, string type, string value)
        {
            var contact = GetContact(contactId);
            if (cdId <= 0 || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(value))
                throw new InvalidContactException("Invalid Contact Details");
                var contactDetail = ContactDetails.CreateNewContactDetail(cdId, type, value);
            contact.ContactDetailsList.Add(contactDetail);
        }

        public static void UpdateContactDetail(int contactId, int contactDetailId, string newValue)
        {
            var contactDetail = GetContactDetail(contactId, contactDetailId);
            contactDetail.Value = newValue;
        }
        public static void DeleteContactDetail(int contactId, int contactDetailId)
        {
            var contact = GetContact(contactId);
            var contactDetail = contact.ContactDetailsList.Find(cd => cd.ContactDetailsID == contactDetailId);
            if (contactDetail == null)
                throw new ContactDetailNotFoundException("Contact Detail Not Found");

            contact.ContactDetailsList.Remove(contactDetail);
        }
        public static List<ContactDetails> DisplayContactDetails(int contactId)
        {
            var contact = GetContact(contactId);
            if (contact.ContactDetailsList.Count == 0)
                throw new EmptyListException("Contact Details List is Empty");
            return contact.ContactDetailsList;
        }

        public static ContactDetails ReadContactDetail(int contactId, int contactDetailId)
        {
            return GetContactDetail(contactId, contactDetailId);
        }

        private static void ValidateActiveUser()
        {
            if (activeUser == null)
                throw new UserNotFoundException("Staff Not Found");
            if (!activeUser.IsActive)
                throw new DeActiveUserException("Staff is Inactive");
        }

        private static Contact GetContact(int contactId)
        {
            ValidateActiveUser();
            var contact = activeUser.Contacts.Find(c => c.ContactID == contactId);
            if (contact == null)
                throw new ContactNotFoundException("Contact Not Found");
            if (!contact.IsActive)
                throw new DeActiveContactException("Contact is Inactive");
            return contact;
        }

        private static ContactDetails GetContactDetail(int contactId, int contactDetailId)
        {
            var contact = GetContact(contactId);
            var contactDetail = contact.ContactDetailsList.Find(cd => cd.ContactDetailsID == contactDetailId);
            if (contactDetail == null)
                throw new ContactDetailNotFoundException("Contact Detail Not Found");
            return contactDetail;
        }
    }
}
