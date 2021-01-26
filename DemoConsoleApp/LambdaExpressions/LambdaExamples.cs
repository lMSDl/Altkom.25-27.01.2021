using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.LambdaExpressions
{
    public class LambdaExamples
    {
        Func<int, int, int> Calculator { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        public void Test()
        {
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(a, b) => { return a + b; };
                          (a, b) => a + b;

            SomeAction += //(param) => Console.WriteLine(a);
                           param => Console.WriteLine(param);

            AnotherAction += () => Console.WriteLine("Action!");


            SomeMethod(x => Console.WriteLine(x), "Hello!");


            SomeMethod(y => {
                var @string = y.Replace(',', '\'');
                Console.WriteLine(@string);
                },
                "ABC, BCD, CDE!");
        }

        void SomeMethod(Action<string> stringAction, string @string)
        {
            stringAction(@string);
        }

    }
}
