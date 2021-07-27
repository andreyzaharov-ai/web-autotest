using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;

namespace web_autotest
{
    [Table(Name = "")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string contactDetailes;
        private string allEmails;

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string SecondaryAddress { get; set; }

        public string HomePhone { get; set; }

        public string SecondaryHomePhone { get; set; }

        public string Notes { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string MonthOfBirth { get; set; }
        public string YearhOfBirth { get; set; }
        public string AnniversaryDay { get; set; }
        public string MonthOfAnniversary { get; set; }
        public string YearOfAnniversary { get; set; }

        /// <summary>
        /// Все мэйлы
        /// </summary>
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
                    return ((Email1) + "\r\n" + (Email2) + "\r\n" + (Email3)).Trim();
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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryHomePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        /// <summary>
        /// Просмотр детальной информации о контакте
        /// </summary>
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
                        (FirstName + " " + MiddleName + " " + LastName + "\r\n"
                        + Nickname + "\r\n"
                        + Title + "\r\n"
                        + Company + "\r\n"
                        + Address + "\r\n\r\n"
                        + "H: " + HomePhone + "\r\n"
                        + "M: " + MobilePhone + "\r\n"
                        + "W: " + WorkPhone + "\r\n"
                        + "F: " + Fax + "\r\n\r\n"
                        + Email1 + "\r\n"
                        + Email2 + "\r\n"
                        + Email3 + "\r\n"
                        + "Homepage:" + "\r\n" + Homepage + "\r\n\r\n"
                        + "Birthday " + Birthday + ". " + MonthOfBirth + " " + YearhOfBirth + " (" + CalculatedAge() + ")" + "\r\n"
                        + "Anniversary " + AnniversaryDay + ". " + MonthOfAnniversary + " " + YearOfAnniversary + " (" + CalculatedAnniversary() + ")" + "\r\n\r\n"
                        + (SecondaryAddress) + "\r\n\r\n"
                        + "P: " + (SecondaryHomePhone) + "\r\n\r\n"
                        + Notes).Trim();
                }
            }
            set
            {
                contactDetailes = value;
            }
        }
        /// <summary>
        /// Метод расчёта возраста
        /// </summary>
        /// <returns></returns>

        public int CalculatedAge()
        {
            //конвертирование даты в числовой формат, для рассчета возраста 
            string bDayInput = Birthday + ". " + MonthOfBirth + " " + YearhOfBirth;
            var bDayDate = DateTime.Parse(bDayInput);

            // считаем возраст
            int years = DateTime.Now.Year - bDayDate.Year;

            // корректировка года
            if (DateTime.Now.Month < bDayDate.Month || (DateTime.Now.Month == bDayDate.Month && DateTime.Now.Day < bDayDate.Day))
                years--;

            return years;
        }

        /// <summary>
        /// Метод расчёта годовщины
        /// </summary>
        /// <returns></returns>

        public int CalculatedAnniversary()
        {
            //конвертирование даты в числовой формат, для рассчета возраста 
            string aDayInput = AnniversaryDay + ". " + MonthOfAnniversary + " " + YearOfAnniversary;
            var aDayDate = DateTime.Parse(aDayInput);
            int years = DateTime.Now.Year - aDayDate.Year;
            if (DateTime.Now.Month < aDayDate.Month || (DateTime.Now.Month == aDayDate.Month && DateTime.Now.Day < aDayDate.Day))
                years--;
            return years;
        }

        /// <summary>
        /// Метод очистки телефонов
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

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

    }
}
