using System;
using EntLibLoggingDemo.Logging;

namespace EntLibLoggingDemo
{
    class Program
    {
        static ILogFactory logFactory = new EntLibLogFactory();

        static void Main(string[] args)
        {
            Test1();
            Test2();
        }

        static void Test1()
        {
            var logger = logFactory.GetLogger();
            logger.Debug("test1 debug");
            logger.Info("test 1 info");
            logger.Error("test1 error");
            logger.Error("test1 error", new Exception("test exception"));
            logger.ErrorFormat("test1 at {0}", DateTime.Now);
        }

        static void Test2()
        {
            // There must be a "BusinessLogic" category source defined in app condig file.
            var logFactory = new EntLibLogFactory("BusinessLogic");
            var logger = logFactory.GetLogger();
            logger.Debug("test2 business logic");
        }
    }
}
