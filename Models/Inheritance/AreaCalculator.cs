using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class AreaCalculator
    {
        public ICollection<IShapeArea> shapes = new List<IShapeArea>();

        public AreaCalculator()
        {
            shapes.Add(new Rectangle() { A = 5 });
            shapes.Add(new Qube() { A = 5 });
            shapes.Add(new Circle() { R = 10 });
        }

        public float CalculateAreaSum()
        {
            float area = 0;
            foreach (var item in shapes)
            {
                area += item.Area;
            }
            return area;
        }
    }
}
