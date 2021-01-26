using DemoConsoleApp.Delegates;
using DemoConsoleApp.LambdaExpressions;
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

            Console.ReadLine();
        }
    }
}
