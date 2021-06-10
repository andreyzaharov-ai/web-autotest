using System;
using System.Collections.Generic;
using System.Text;

namespace web_autotest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;

        public ContactData()
        {
        }

        public ContactData(string username, string lastname)
        {
            this.firstname = username;
            this.lastname = lastname;

        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
            
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName == other.FirstName && LastName == other.LastName)
            {
                return 0;
            }
            return -1;

        }
        public override string ToString()
        {
            return "FirstName=" + FirstName + "LastName" + LastName;
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
