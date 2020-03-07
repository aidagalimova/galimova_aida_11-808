using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
    public class NotLongLengthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.ToString().Length < 1000)
                return true;
            return false;
        }
    }
}
