using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace web_autotest
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string contactDetailes;
        private string allEmails;

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
            return FirstName == other.FirstName & LastName == other.LastName;
            
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Equals(this.LastName, other.LastName))
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);

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

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return ((Email) + "\r\n" +(Email2) + "\r\n" + (Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
       

        /// <summary>
        /// Метод получения всех телефонов контакта
        /// </summary>
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

        public string ContactDetails
        {
            get
            {
                if (contactDetailes != null)
                {
                    return contactDetailes;
                }
                else
                {
                    return
                        (FirstName + " " + LastName + "\r\n"
                        + Address + "\r\n\r\n"
                        + "H: " + HomePhone + "\r\n"
                        + "M: " + MobilePhone + "\r\n"
                        + "W: " + WorkPhone + "\r\n\r\n"
                        + Email + "\r\n"
                        + Email2 + "\r\n"
                        + Email3 + "\r\n").Trim();
                }
            }
            set
            {
                contactDetailes = value;
            }
        }

        public string Id { get; set; }

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
