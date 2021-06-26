using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace web_autotest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;

        }

        public ContactData()
        {
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

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        

        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        /// <summary>
        /// Метод очистки телефонов
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>

        private string CleanUp(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","") + "\r\n";
        }
    }
}
