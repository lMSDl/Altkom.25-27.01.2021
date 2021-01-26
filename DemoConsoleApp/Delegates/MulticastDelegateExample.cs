using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Delegates
{
    public class MulticastDelegateExample
    {
        public delegate void ShowMessage(string s);

        public void Message1(string msg)
        {
            Console.WriteLine($"1st message: {msg}");
        }

        public void Message2(string msg)
        {
            Console.WriteLine($"2nd message: {msg}");
        }

        public void Message3(string msg)
        {
            Debug.WriteLine($"3rd message: {msg}");
        }


        public void Test()
        {
            ShowMessage showMessage = null;

            showMessage += Message1;
            showMessage += Message2;
            showMessage += Message3;
            showMessage += Console.WriteLine;

            showMessage("Hello");

            showMessage -= Message2;
            showMessage("Message2 removed");

            showMessage = Message2;
            showMessage("hi!");

        }
    }
}
