using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Delegates
{
    public class DelegateExample
    {
        public delegate void NoParametersNoReturnTypeDelegate();
        public delegate void NoReturnTypeDelegate(string someString);
        public delegate bool ReturnAndParametersDelegate(int x, int y);

        public void Func1()
        {
            Console.WriteLine("1");
        }

        public void Func2(string @string)
        {
            Console.WriteLine(@string);
        }

        public bool Func3(int x, int y)
        {
            Console.WriteLine($"3: {x} {y}");
            return x == y;
        }

        public ReturnAndParametersDelegate Delegate3 { get; set; }

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnTypeDelegate(Func1);
            delegate1();

            NoReturnTypeDelegate delegate2 = null;

            if(delegate2 != null)
                delegate2("2");

            /*if (delegate2 != null)
                delegate2.Invoke("2");*/
            delegate2?.Invoke("2");

            delegate2 = Func2;
            delegate2("2");

            Delegate3 = Func3;

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    if(Delegate3(i, ii))
                        Console.WriteLine("==");
                }
            }

        }
    }
}
