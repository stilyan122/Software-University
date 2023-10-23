using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IResidents
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
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
