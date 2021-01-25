using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class Rectangle : Shape2D
    {
        public float A { get; set; }

        public override float Area => A * A;

        public override float CalculatePerimeter()
        {
            return 4 * A;
        }
    }
}
