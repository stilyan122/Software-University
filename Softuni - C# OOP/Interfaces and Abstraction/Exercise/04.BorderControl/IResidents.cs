using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IResidents
    {
        public string Id { get; set; }
        public bool Check(int number);
    }
}
