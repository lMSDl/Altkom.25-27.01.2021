using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Extensions
{
    public static class StringExtensions
    {

        public static DateTime? ToDateTime(this string @string)
        {
            if (DateTime.TryParse(@string, out var birthDate))
                return birthDate;
            else
                return null;
        }

        public static Gender? ToGender(this string @string)
        {
            if (Enum.TryParse<Gender>(@string, out var gender))
            {
                if(Enum.IsDefined(typeof(Gender), gender))
                    return gender;
            }
            return null;
        }
    }
}
