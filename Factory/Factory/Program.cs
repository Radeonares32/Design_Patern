using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new FactoryLogger());
            customerManager.Save();
            
        }
    }

    public class FactoryLogger : IloggerFactory
    {
        public ILogger createLogger()
        {
            return new BALogger();
        }
    }

   public interface IloggerFactory
   {
       ILogger createLogger();
   }

    public interface ILogger
    {
        void Log();
    }

    public class CustomerManager
    {
        private IloggerFactory _logger;

        public CustomerManager(IloggerFactory _logger)
        {
            this._logger = _logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _logger.createLogger();
            logger.Log();
        }
    }

    public class BALogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Ba Logger");
        }
    }
}