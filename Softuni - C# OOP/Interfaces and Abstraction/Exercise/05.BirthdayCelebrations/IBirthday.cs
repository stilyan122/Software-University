using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IBirthday
    {
        public string Birthday { get; set; }
        public bool Check(string birthday);
    }
}
