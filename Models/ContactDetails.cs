using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; } 
        public string Value { get; set; }

        public ContactDetails(int id , string type , string value)
        {
            ContactDetailsID = id;
            Type = type;
            Value = value;
        }

        public static ContactDetails CreateNewContactDetail(int id, string type , string value)
        {
            return new ContactDetails(id, type , value);
        }


        public override string ToString()
        {
            return $"Contact Detail Id : {ContactDetailsID}\n" +
                $"Contact Detail Type : {Type}\n" +
                $"Contact Detail Value : {Value}\n";
        }
    }
}
