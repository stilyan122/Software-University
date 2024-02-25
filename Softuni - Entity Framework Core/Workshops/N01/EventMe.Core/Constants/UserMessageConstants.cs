using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMe.Core.Constants
{
    public static class UserMessageConstants
    {
        public const string Required = "Field {0} is a must!";
        public const string StringLength = "Field {0} needs to be between {2} and {1} characters";
        public const string UnknownError = "An unexpected error occured!";
    }
}
