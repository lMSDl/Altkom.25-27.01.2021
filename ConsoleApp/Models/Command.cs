using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Command
    {
        public string Action { get; }
        //public Nullable<int> Parameter { get; }
        public int? Parameter { get; private set; }

        public Command(string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
                return;

            var split = @string.Split(' ');
            Action = split[0];

            if (split.Length > 1)
                ReadParameter(split[1]);

        }

        private void ReadParameter(string @string)
        {
            //Parameter = int.Parse(split[1]);

            /*int result;
            if (int.TryParse(@string, out result))
                Parameter = result;*/

            if (int.TryParse(@string, out int result))
                Parameter = result;
        }
    }
}
