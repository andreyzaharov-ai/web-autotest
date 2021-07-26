using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_autotest;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] - количество тествоых данных, которые надо сгенерировать
            int count = Convert.ToInt32(args[0]);
            //args[1] - название файла, в который передается значение
            string filename = args[1];
            //формат тестовых данных
            string format = args[2];
            //тип данных контакты или группы
            string type = args[3];

            if (type == "groups")
            {
                //Создание данных для групп
                List<GroupData> groups = new List<GroupData>();
                //генерация тестовых данных
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData()
                    {
                        Name = TestBase.GenerateRandomString(10),
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                //Пишем данные в файл. filename - название файла, в который передается значение
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }


            else if (type == "contacts")
            {            //Создание данных для контактов
                List<ContactData> contacts = new List<ContactData>();
                //генерация тестовых данных
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        FirstName = TestBase.GenerateRandomString(10),
                        LastName = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10)
                    });
                }

                //Пишем данные в файл. filename - название файла, в который передается значение
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        

            else Console.WriteLine("Unknown data type");




        }

        /// <summary>
        /// Метод записи данных групп в JSON 
        /// </summary>
        /// <param name="groups">группы</param>
        /// <param name="writer">файл</param>
        private static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        /// <summary>
        /// Метод записи данных контактов в JSON
        /// </summary>
        /// <param name="contacts">контакты</param>
        /// <param name="writer">файл</param>
        private static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
        /// <summary>
        /// Метод записи данных групп в Xml 
        /// </summary>
        /// <param name="groups">группы</param>
        /// <param name="writer">файл</param>
        private static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }
        /// <summary>
        /// Метод записи данных контактов в Xml
        /// </summary>
        /// <param name="contacts">контакты</param>
        /// <param name="writer">файл</param>
        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
 }

