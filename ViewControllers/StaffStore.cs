using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Exceptions;
using ContactApp.Repositories;

namespace ContactApp.ViewControllers
{
    internal class StaffStore
    {
        public static void Display()
        {
            while (true)
            {
                Console.WriteLine("\nStaff Panel\n" +
                    "\n============ Contact ===============\n" +
                   "\n1. Create Contact\n" +
                   "2. Update Contact\n" +
                   "3. Delete Contact\n" +
                   "4. Display All Contacts\n" +
                   "5. Find Contact By Id\n" +
                   "\n\n============= Contact Details =============\n" +
                   "\n6. Create Contact Details\n" +
                   "7. Update Contact Details\n" +
                   "8. Delete Contact Details\n" +
                   "9. Display All Contact Details\n" +
                   "10. Display Contact Details By Id\n" +
                   "11. Logout");
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
                        AddContact();
                        break;
                    case 2:
                        UpdateContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayContacts();
                        break;
                    case 5:
                        FindContact();
                        break;
                    case 6:
                        AddContactDetails();
                        break;
                    case 7:
                        UpdateContactDetails();
                        break;
                    case 8:
                        DeleteContactDetails();
                        break;
                    case 9:
                        DisplayContactDetails();
                        break;
                    case 10:
                        FindContactDetails();
                        break;
                    case 11:
                        UserStore.DisplayMenu();
                        break;
                }
            }
            catch(ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DuplicateContactException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DuplicateUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InvalidContactException ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            catch(ContactDetailNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DeActiveContactException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DeActiveUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(UserNotFoundException ex)
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


        public static void AddContact()
        {
            Console.WriteLine("Enter Contact Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact FirstName : ");
            string firstName  = Console.ReadLine();
            Console.WriteLine("Enter Contact LastName : ");
            string lastName = Console.ReadLine();
            try
            {
                Staff.CreateContact(id, firstName, lastName);
                Console.WriteLine("\nContact Added Successfully");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public  static void UpdateContact()
        {
            Console.WriteLine("Enter Contact Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Updated First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Updated Last Name");
            string lastName = Console.ReadLine();
            try
            {
                Staff.UpdateContact(id, firstName, lastName);
                Console.WriteLine("\nContact Updated Successfully");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
        }

        public static void DeleteContact() {
            Console.WriteLine("Enter Contact Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                Staff.DeleteContact(id);
                Console.WriteLine("\nContact Deleted Successfully");
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
            

        public static void DisplayContacts()
        {
            try
            {
                var contacts = Staff.DisplayContacts();
                foreach (var contact in contacts)
                {
                    Console.WriteLine("\n=======================");
                    Console.WriteLine(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FindContact()
        {
            Console.WriteLine("Enter Contact Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var contact = Staff.FindContactById(id);
                Console.WriteLine("\n=======================");
                Console.WriteLine(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddContactDetails()
        {
            Console.WriteLine("Enter Contact Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Details Id: ");
            int CdId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Type (e.g., Phone, Email): ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Contact Detail Value: ");
            string value = Console.ReadLine();
            try
            {
                Staff.CreateContactDetail(id, CdId ,  type, value);
                Console.WriteLine("\nContact Detail Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateContactDetails()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Updated Value: ");
            string newValue = Console.ReadLine();
            try
            {
                Staff.UpdateContactDetail(contactId, contactDetailId, newValue);
                Console.WriteLine("\nContact Details updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteContactDetails()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            try
            {
                Staff.DeleteContactDetail(contactId, contactDetailId);
                Console.WriteLine("\nContactDetail Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplayContactDetails()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            try
            {
                var contactDetails = Staff.DisplayContactDetails(contactId);
                foreach (var contactDetail in contactDetails)
                {
                    Console.WriteLine("\n=======================");
                    Console.WriteLine(contactDetail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FindContactDetails()
        {
            Console.WriteLine("Enter Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Detail Id: ");
            int contactDetailId = Convert.ToInt32(Console.ReadLine());
            try
            {
                var contactDetail = Staff.ReadContactDetail(contactId, contactDetailId);
                Console.WriteLine("\n=======================");
                Console.WriteLine(contactDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
