using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Delegates
{
    public class BuildInDelegatesExample
    {
        public event EventHandler<OddNumberEventArgs> OddNumberEvent;

        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                OddNumberEvent?.Invoke(this, new OddNumberEventArgs { Result = result });
        }

        private int _counter = 0;
        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            OddNumberEvent += BuildInDelegatesExample_OddNumberEvent;
            OddNumberEvent += delegate (object sender, OddNumberEventArgs eventArgs) { Console.WriteLine($"*** Odd number ({eventArgs.Result}) detected ***"); };
            Method(Add, Substract);

            Console.WriteLine("Counter: " + _counter);
        }


        //public delegate void Method1Delegate(int a, int b);
        //public delegate bool Method2Delegate(int a, int b);
        //private void Method(Method1Delegate method1, Method2Delegate method2)
        private void Method(Action<int, int> method1, Func<int, int, bool> method2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    method1(i, ii);
                    if (method2(i, ii))
                        OddNumberEvent?.Invoke(this, new OddNumberEventArgs());
                }
            }
        }

        private void BuildInDelegatesExample_OddNumberEvent(object sender, EventArgs e)
        {
            CountOddNumbers();
        }

        public class OddNumberEventArgs : EventArgs
        {
            public int? Result { get; set; }
        }
    }
}
