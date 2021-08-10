using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StopLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }


        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    class NLogLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    class StopLogger:ILogger
    {
        private static StopLogger _stopLogger;
        private static object _lock = new object();
        private StopLogger() { }

        public static StopLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stopLogger == null)
                {
                    _stopLogger = new StopLogger();
                }
            }

            return _stopLogger;
        }
        public void Log()
        {
            
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StopLogger.GetLogger());
            customerManager.Save();
        }
    }
    
}