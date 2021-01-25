using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class Circle : Shape2D
    {
        public float R { get; set; }

        public override float Area => (float)(Math.PI * R * R);

        public override float CalculatePerimeter()
        {
            return (float)(Math.PI * 2 * R);
        }
    }
}
