using System;
using System.Collections.Generic;
using System.Text;

namespace web_autotest
{
    public class ContactData
    {
        private string firstname;
        private string lastname;

        public ContactData(string username, string password)
        {
            this.firstname = username;
            this.lastname = password;

        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }


    }
}
