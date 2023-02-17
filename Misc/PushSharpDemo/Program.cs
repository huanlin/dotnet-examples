using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using PushSharp;
using PushSharp.Core;
using PushSharp.Apple;
using PushSharp.Android;

namespace PushSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AppPushDemo demo = new AppPushDemo();

            demo.SendPushMessage("Hello from Michael's test tool.");
            
            Console.WriteLine("Queue Finished, press return to exit...");
            Console.ReadLine();	
        }
    }
}
