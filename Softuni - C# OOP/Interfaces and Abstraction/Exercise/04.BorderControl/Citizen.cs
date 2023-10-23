using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IResidents
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public bool Check(int number)
        {
            if (this.Id.EndsWith(number.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
