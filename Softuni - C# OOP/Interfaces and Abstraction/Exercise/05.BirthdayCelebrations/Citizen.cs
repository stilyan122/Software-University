using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IBirthday
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id,string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get;set; }

        public bool Check(string birthday)
        {
            string[] birthdaySplitted = this.Birthday.Split("/");
            string year = birthdaySplitted[2];
            if (year==birthday)
            {
                return true;
            }
            return false;
        }
    }
}
