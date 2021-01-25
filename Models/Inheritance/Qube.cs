using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class Qube : Shape3D
    {
        public float A { get; set; }


        public override float Volume => A * A * A;

        public override float Area => 6 * A * A;
    }
}
