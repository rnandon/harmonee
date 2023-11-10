using harmonee.Shared.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Auth
{
    public class User : Storable
    {
        private string FirstName;
        private string LastName;
        private string Email;
        private string Phone;

        public User()
        {
            
        }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }

        public string SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            return GetName();
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetPhone()
        {
            return Phone;
        }

        public void SetPhone(string phone)
        {
            Phone = phone;
        }
    }
}
