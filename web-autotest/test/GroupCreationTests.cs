using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace web_autotest
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        /// <summary>
        /// Метод чтения групп, сгенерированных в формате JSON
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"C:\Users\Andrey\source\repos\web-autotest\web-autotest\groups.json"));

        }
        /// <summary>
        /// Метод чтения групп, сгенерированных в формате XML
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            List<GroupData> groups = new List<GroupData>();

            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"C:\Users\Andrey\source\repos\web-autotest\web-autotest\groups.xml"));
            
        }
        /// <summary>
        /// Тест создания группы
        /// </summary> 
        [Test, TestCaseSource("GroupDataFromXMLFile")]
        public void TheGroupCreationTest(GroupData group)
        {
          /*  GroupData group = new GroupData()
            {
                Name = GenerateRandomString(5),
                Header = GenerateRandomString(5),
                Footer = GenerateRandomString(5)
            }; */

            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            
            Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;

            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
