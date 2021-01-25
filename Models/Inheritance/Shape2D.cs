using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public abstract class Shape2D : Shape, IShapeArea
    {
        public abstract float Area { get; }
        public abstract float CalculatePerimeter();
    }
}
