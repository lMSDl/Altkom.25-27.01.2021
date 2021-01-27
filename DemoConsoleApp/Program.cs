using DemoConsoleApp.Delegates;
using DemoConsoleApp.LambdaExpressions;
using DemoConsoleApp.SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new DelegateExample().Test();
            new MulticastDelegateExample().Test();
            var eventExample = new EventExample();

            //eventExample.OddNumberEvent = null;
            eventExample.OddNumberDelegateDelegate = null;

                eventExample.Test();
            new BuildInDelegatesExample().Test();
            new LambdaExamples().Test();
            new LinqExamples().Test();

            //CalcRectabgleArea(new SOLID.L.Square(), 5, 3);

            Console.ReadLine();
        }

        private static void CalcRectabgleArea(SOLID.L.Rectangle rectangle, int a, int b)
        {
            rectangle.A = a;
            rectangle.B = b;

            Console.WriteLine($"{a} * {b} = {rectangle.Area}" );
        }
    }
}
