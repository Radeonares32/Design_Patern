using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory());
            productManager.GetAll();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public abstract class Caching
    {
        public abstract void Cache(string message);
    }

    public class Log4Net : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Memory : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine(message);
        }
    }

    public abstract class CCC
    {
        public abstract Logging CreateLogging();
        public abstract Caching CreateCaching();
    }

    public class Factory : CCC
    {
        public override Logging CreateLogging()
        {
            return new Log4Net();
        }

        public override Caching CreateCaching()
        {
            return new Memory();
        }
    }
    public class ProductManager
    {
        private CCC _factory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CCC factory)
        {
            _factory = factory;
            _logging = _factory.CreateLogging();
            _caching = _factory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Log");
            _caching.Cache("Data");
            Console.WriteLine("Get all ");
        }
    }
}