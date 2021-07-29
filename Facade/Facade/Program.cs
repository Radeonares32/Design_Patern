using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface Ilogger
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class CustomerManager
    {
        private CrossCuttongConcersFacade _concersFacade;

        public CustomerManager()
        {
            _concersFacade = new CrossCuttongConcersFacade();
        }

        public void Save()
        {
            _concersFacade.caching.Cache();
            _concersFacade.logger.Log();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttongConcersFacade
    {
        public Ilogger logger;
        public ICaching caching;

       public CrossCuttongConcersFacade()
       {
           logger = new Logging();
           caching = new Caching();
       }
    }
}