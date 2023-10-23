using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        private string birthday;
        private string name;

        public Pet(string name,string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Birthday { get; set; }
        public string Name { get; set; }

        public bool Check(string birthday)
        {
            string[] birthdaySplitted = this.Birthday.Split("/");
            string year = birthdaySplitted[2];
            if (year == birthday)
            {
                return true;
            }
            return false;
        }
    }
}
