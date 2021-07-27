﻿using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;
using System.Linq;

namespace web_autotest
{
    [Table(Name = "group_list")]
    public class GroupData: IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        {
            Name = name;
            
        }
        public GroupData()
        {
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) && (Id == other.Id);
        }

        public override int GetHashCode()
        {
            return (Name + Id).GetHashCode();
        }

        public override string ToString()
        {
            return "ID=" + Id +"name=" + Name + ", header = " + Header + ", footer= " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Id.CompareTo(other.Id);
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }
        
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll() {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

    }
}
